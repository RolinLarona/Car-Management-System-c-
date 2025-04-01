using System;
using System.Net.Mail;
using System.Net;
using MySql.Data.MySqlClient;
using final;

    class Program
    {
        static void Main()
        {
            string connectionString = "server=localhost;database=CarRentalDB;user=root;password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();




                    Console.WriteLine(@"
                       
                                 ---------------------------.
                               `/""""/""""/|""|'|""||""|   ' \.
                               /    /    / |__| |__||__|      |
                              /----------=====================|
                              | \  /V\  /    _.               |
                               ()\ \W/ /()   _            _   |
                              |   \   /     / \          / \  |-( )
                              =C========C==_| ) |--------| ) _/==] _-{_}_)
                                \_\_/__..  \_\_/_ \_\_/ \_\_/__.__.    
╔═╗╔═╗╔═╗╦ ╦╦═╗  ╔═╗╔═╗╦═╗  ╦═╗╔═╗╔╗╔╔╦╗╔═╗╦    ╔╦╗╔═╗╔╗╔╔═╗╔═╗╔═╗╔╦╗╔═╗╔╗╔╔╦╗  ╔═╗╦ ╦╔═╗╔╦╗╔═╗╔╦╗
║ ╦╠╣ ║ ║║ ║╠╦╝  ║  ╠═╣╠╦╝  ╠╦╝║╣ ║║║ ║ ╠═╣║    ║║║╠═╣║║║╠═╣║ ╦║╣ ║║║║╣ ║║║ ║   ╚═╗╚╦╝╚═╗ ║ ║╣ ║║║
╚═╝╚  ╚═╝╚═╝╩╚═  ╚═╝╩ ╩╩╚═  ╩╚═╚═╝╝╚╝ ╩ ╩ ╩╩═╝  ╩ ╩╩ ╩╝╚╝╩ ╩╚═╝╚═╝╩ ╩╚═╝╝╚╝ ╩   ╚═╝ ╩ ╚═╝ ╩ ╚═╝╩ ╩
");
                    Console.WriteLine("=================================================================================================\n");
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = "";
                    ConsoleKeyInfo key;

                    do
                    {
                        key = Console.ReadKey(intercept: true);
                        if (key.Key != ConsoleKey.Enter)
                        {
                            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                            {

                                password = password.Substring(0, password.Length - 1);
                                Console.Write("\b \b");
                            }
                            else if (key.Key != ConsoleKey.Backspace)
                            {
                                password += key.KeyChar;
                                Console.Write("*");
                            }
                        }
                    } while (key.Key != ConsoleKey.Enter);

                    Console.WriteLine();


                    string loginQuery = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                    MySqlCommand loginCommand = new MySqlCommand(loginQuery, connection);
                    loginCommand.Parameters.AddWithValue("@Username", username);
                    loginCommand.Parameters.AddWithValue("@Password", password);

                    MySqlDataReader loginReader = loginCommand.ExecuteReader();

                    if (loginReader.Read())
                    {
                        Console.Clear();
                        Console.WriteLine(@"
                       
                                 ---------------------------.
                               `/""""/""""/|""|'|""||""|   ' \.
                               /    /    / |__| |__||__|      |
                              /----------=====================|
                              | \  /V\  /    _.               |
                               ()\ \W/ /()   _            _   |
                              |   \   /     / \          / \  |-( )
                              =C========C==_| ) |--------| ) _/==] _-{_}_)
                                \_\_/__..  \_\_/_ \_\_/ \_\_/__.__.    
╔═╗╔═╗╔═╗╦ ╦╦═╗  ╔═╗╔═╗╦═╗  ╦═╗╔═╗╔╗╔╔╦╗╔═╗╦    ╔╦╗╔═╗╔╗╔╔═╗╔═╗╔═╗╔╦╗╔═╗╔╗╔╔╦╗  ╔═╗╦ ╦╔═╗╔╦╗╔═╗╔╦╗
║ ╦╠╣ ║ ║║ ║╠╦╝  ║  ╠═╣╠╦╝  ╠╦╝║╣ ║║║ ║ ╠═╣║    ║║║╠═╣║║║╠═╣║ ╦║╣ ║║║║╣ ║║║ ║   ╚═╗╚╦╝╚═╗ ║ ║╣ ║║║
╚═╝╚  ╚═╝╚═╝╩╚═  ╚═╝╩ ╩╩╚═  ╩╚═╚═╝╝╚╝ ╩ ╩ ╩╩═╝  ╩ ╩╩ ╩╝╚╝╩ ╩╚═╝╚═╝╩ ╩╚═╝╝╚╝ ╩   ╚═╝ ╩ ╚═╝ ╩ ╚═╝╩ ╩ 
");

                        Console.WriteLine("=================================================================================================\n");
                        Console.WriteLine("Login successful! Welcome, " + username + " ADMIN\n");
                        loginReader.Close();
                        ShowMenu(connection);
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password. Please try again.");
                        loginReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void ShowMenu(MySqlConnection connection)
        {
            while (true)
            {

                Console.WriteLine("\n[1] View Available Vehicles");
                Console.WriteLine("[2] Rent a Vehicle");
                Console.WriteLine("[3] Return a Vehicle");
                Console.WriteLine("[4] View Rental History");
                Console.WriteLine("[5] Reserve a Car/Van");
                Console.WriteLine("[6] View Reservations");
                Console.WriteLine("[7] Add Vehicle");
                Console.WriteLine("[8] Delete Vehicle");
                Console.WriteLine("[9] Exit");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            DisplayVehicles(connection);
                            break;
                        case 2:
                            RentVehicle(connection);
                            break;
                        case 3:
                            ReturnVehicle(connection);
                            break;
                        case 4:
                            ViewRentalHistory(connection);
                            break;
                        case 5:
                            ReserveVehicle(connection);
                            break;
                        case 6:
                            ViewReservations(connection);
                            break;
                        case 7:
                            AddVehicle(connection);
                            break;
                        case 8:
                            DeleteVehicle(connection);
                            break;
                        case 9:
                            Console.WriteLine("THANK YOU AND GOODBYE <3");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void DisplayVehicles(MySqlConnection connection)
        {
            string query = "SELECT * FROM Vehicles WHERE Available = 1";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.Clear();
            Console.WriteLine("==================================================================================");
            Console.WriteLine(@"           

 █████╗ ██╗   ██╗ █████╗ ██╗██╗      █████╗ ██████╗ ██╗     ███████╗    ██╗   ██╗███████╗██╗  ██╗██╗ ██████╗██╗     ███████╗███████╗
██╔══██╗██║   ██║██╔══██╗██║██║     ██╔══██╗██╔══██╗██║     ██╔════╝    ██║   ██║██╔════╝██║  ██║██║██╔════╝██║     ██╔════╝██╔════╝
███████║██║   ██║███████║██║██║     ███████║██████╔╝██║     █████╗      ██║   ██║█████╗  ███████║██║██║     ██║     █████╗  ███████╗
██╔══██║╚██╗ ██╔╝██╔══██║██║██║     ██╔══██║██╔══██╗██║     ██╔══╝      ╚██╗ ██╔╝██╔══╝  ██╔══██║██║██║     ██║     ██╔══╝  ╚════██║
██║  ██║ ╚████╔╝ ██║  ██║██║███████╗██║  ██║██████╔╝███████╗███████╗     ╚████╔╝ ███████╗██║  ██║██║╚██████╗███████╗███████╗███████║
╚═╝  ╚═╝  ╚═══╝  ╚═╝  ╚═╝╚═╝╚══════╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚══════╝      ╚═══╝  ╚══════╝╚═╝  ╚═╝╚═╝ ╚═════╝╚══════╝╚══════╝╚══════╝
                                                                                                                                                                                                  ");
            Console.WriteLine("==================================================================================");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["VehicleID"]} - {reader["Model"]} ({reader["Type"]}) - P{reader["PricePerDay"]}/day");
            }
            reader.Close();
        }

        static void RentVehicle(MySqlConnection connection)
        {
            DisplayVehicles(connection);

            Console.Write("\nEnter Vehicle ID to rent: ");
            if (int.TryParse(Console.ReadLine(), out int vehicleID))
            {
                string availabilityQuery = "SELECT Available FROM Vehicles WHERE VehicleID = @VehicleID";
                MySqlCommand availabilityCommand = new MySqlCommand(availabilityQuery, connection);
                availabilityCommand.Parameters.AddWithValue("@VehicleID", vehicleID);
                object result = availabilityCommand.ExecuteScalar();

                if (result != null && Convert.ToInt32(result) == 1)
                {
                    Console.Write("Enter Customer Name: ");
                    string customerName = Console.ReadLine();

                    Console.Write("Enter Customer Email: ");
                    string customerEmail = Console.ReadLine();

                    Console.Write("Enter Rental Days: ");
                    if (int.TryParse(Console.ReadLine(), out int rentalDays))
                    {
                        string query = "INSERT INTO Rentals (VehicleID, CustomerName, CustomerEmail, RentDate, ReturnDate, TotalCost) " +
                                       "VALUES (@VehicleID, @CustomerName, @CustomerEmail, NOW(), DATE_ADD(NOW(), INTERVAL @RentalDays DAY), " +
                                       "(SELECT PricePerDay FROM Vehicles WHERE VehicleID = @VehicleID) * @RentalDays)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@VehicleID", vehicleID);
                        command.Parameters.AddWithValue("@CustomerName", customerName);
                        command.Parameters.AddWithValue("@CustomerEmail", customerEmail);
                        command.Parameters.AddWithValue("@RentalDays", rentalDays);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            string updateAvailability = "UPDATE Vehicles SET Available = 0 WHERE VehicleID = @VehicleID";
                            MySqlCommand updateCommand = new MySqlCommand(updateAvailability, connection);
                            updateCommand.Parameters.AddWithValue("@VehicleID", vehicleID);
                            updateCommand.ExecuteNonQuery();

                            string detailsQuery = "SELECT CustomerName, CustomerEmail, RentDate, ReturnDate, TotalCost FROM Rentals WHERE RentalID = LAST_INSERT_ID()";
                            MySqlCommand detailsCommand = new MySqlCommand(detailsQuery, connection);
                            MySqlDataReader reader = detailsCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                string rentDate = Convert.ToDateTime(reader["RentDate"]).ToString("yyyy-MM-dd");
                                string returnDate = Convert.ToDateTime(reader["ReturnDate"]).ToString("yyyy-MM-dd");
                                string totalCost = $"P{reader["TotalCost"]}";

                                Console.WriteLine("\n✅ Vehicle rented successfully!");
                                Console.WriteLine($"Customer: {reader["CustomerName"]}");
                                Console.WriteLine($"Email: {reader["CustomerEmail"]}");
                                Console.WriteLine($"Rent Date: {rentDate}");
                                Console.WriteLine($"Return Date: {returnDate}");
                                Console.WriteLine($"Total Cost: {totalCost}");

                                // Send Email Notification
                                EmailService emailService = new EmailService();
                                string subject = "Rental Confirmation - Car Rental Service";
                                string body = $"<h2>Rental Confirmation</h2>" +
                                              $"<p>Dear {customerName},</p>" +
                                              $"<p>Your vehicle rental has been successfully confirmed.</p>" +
                                              $"<p><strong>Rent Date:</strong> {rentDate}</p>" +
                                              $"<p><strong>Return Date:</strong> {returnDate}</p>" +
                                              $"<p><strong>Total Cost:</strong> {totalCost}</p>" +
                                              $"<p>Thank you for choosing G4 Car Rental service!</p>";

                                emailService.SendEmail(customerEmail, subject, body);
                            }
                            reader.Close();
                        }
                        else
                        {
                            Console.WriteLine("❌ Failed to rent vehicle.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid rental days.");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Vehicle is not available or invalid ID.");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid vehicle ID.");
            }
        }


    static void ReturnVehicle(MySqlConnection connection)
    {
        ViewRentalHistory(connection);

        Console.Write("\nEnter Rental ID to return: ");
        if (int.TryParse(Console.ReadLine(), out int rentalId))
        {
            // Get rental details
            string rentalQuery = "SELECT RentDate, ReturnDate, TotalCost, VehicleID, CustomerEmail FROM Rentals WHERE RentalID = @RentalID";
            MySqlCommand rentalCommand = new MySqlCommand(rentalQuery, connection);
            rentalCommand.Parameters.AddWithValue("@RentalID", rentalId);
            MySqlDataReader reader = rentalCommand.ExecuteReader();

            if (reader.Read())
            {
                DateTime rentDate = Convert.ToDateTime(reader["RentDate"]);
                object expectedReturnDateObj = reader["ReturnDate"];
                decimal totalCost = Convert.ToDecimal(reader["TotalCost"]);
                int vehicleID = Convert.ToInt32(reader["VehicleID"]);
                string customerEmail = reader["CustomerEmail"].ToString();
                reader.Close();

                Console.Write("Enter actual return date (YYYY-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime actualReturnDate))
                {
                    int lateDays = 0;
                    decimal lateFee = 0;
                    if (expectedReturnDateObj != DBNull.Value)
                    {
                        DateTime expectedReturnDate = Convert.ToDateTime(expectedReturnDateObj);
                        if (actualReturnDate > expectedReturnDate)
                        {
                            lateDays = (actualReturnDate - expectedReturnDate).Days;
                            lateFee = lateDays * (totalCost / (expectedReturnDate - rentDate).Days);
                            totalCost += lateFee;
                        }
                    }

                    
                    string updateQuery = "UPDATE Rentals SET ActualReturnDate = @ActualReturnDate, TotalCost = @TotalCost WHERE RentalID = @RentalID";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@ActualReturnDate", actualReturnDate);
                    updateCommand.Parameters.AddWithValue("@TotalCost", totalCost);
                    updateCommand.Parameters.AddWithValue("@RentalID", rentalId);
                    updateCommand.ExecuteNonQuery();

                 
                    string updateVehicleQuery = "UPDATE Vehicles SET Available = 1 WHERE VehicleID = @VehicleID";
                    MySqlCommand updateVehicleCommand = new MySqlCommand(updateVehicleQuery, connection);
                    updateVehicleCommand.Parameters.AddWithValue("@VehicleID", vehicleID);
                    updateVehicleCommand.ExecuteNonQuery();

                    Console.WriteLine("\n✅ Vehicle returned successfully!");
                    if (lateDays > 0)
                    {
                        Console.WriteLine($"Late return! {lateDays} days late. Additional fee applied: P{lateFee}");
                    }
                    Console.WriteLine($"Total Cost: P{totalCost}");

                    
                    EmailService emailService = new EmailService();
                    string subject = "Return Confirmation - Car Rental Service";
                    string body = $"<h2>Return Confirmation</h2>" +
                                  $"<p>Your vehicle has been successfully returned.</p>" +
                                  $"<p><strong>Actual Return Date:</strong> {actualReturnDate:yyyy-MM-dd}</p>" +
                                  (lateDays > 0 ? $"<p><strong>Late Fee:</strong> P{lateFee} ({lateDays} days late)</p>" : "") +
                                  $"<p><strong>Total Cost:</strong> P{totalCost}</p>" +
                                  $"<p>Thank you for using G4 Car Rental service!</p>";

                    emailService.SendEmail(customerEmail, subject, body);
                }
                else
                {
                    Console.WriteLine("❌ Invalid return date.");
                }
            }
            else
            {
                Console.WriteLine("❌ Rental ID not found.");
            }
        }
        else
        {
            Console.WriteLine("❌ Invalid input.");
        }
    }



    static void ViewRentalHistory(MySqlConnection connection)
        {
            string query = "SELECT r.RentalID, r.VehicleID, r.RentDate, r.ReturnDate, r.TotalCost, r.CustomerName, r.CustomerEmail FROM Rentals r";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.Clear();
            Console.WriteLine("==================================================================================");
            Console.WriteLine(@" 

 ██████╗ ███████╗███╗   ██╗████████╗ █████╗ ██╗         ██╗  ██╗██╗███████╗████████╗ ██████╗ ██████╗ ██╗   ██╗
██╔══██╗██╔════╝████╗  ██║╚══██╔══╝██╔══██╗██║         ██║  ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
██████╔╝█████╗  ██╔██╗ ██║   ██║   ███████║██║         ███████║██║███████╗   ██║   ██║   ██║██████╔╝ ╚████╔╝ 
██╔══██╗██╔══╝  ██║╚██╗██║   ██║   ██╔══██║██║         ██╔══██║██║╚════██║   ██║   ██║   ██║██╔══██╗  ╚██╔╝  
██║  ██║███████╗██║ ╚████║   ██║   ██║  ██║███████╗    ██║  ██║██║███████║   ██║   ╚██████╔╝██║  ██║   ██║   
╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝╚══════╝    ╚═╝  ╚═╝╚═╝╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝                                                                                                                      ");
            Console.WriteLine("==================================================================================");
            while (reader.Read())
            {
                string rentDate = reader["RentDate"] != DBNull.Value && DateTime.TryParse(reader["RentDate"].ToString(), out DateTime rentDt)
                    ? rentDt.ToString("yyyy-MM-dd HH:mm:ss")
                    : "N/A";

                string returnDate = reader["ReturnDate"] != DBNull.Value && DateTime.TryParse(reader["ReturnDate"].ToString(), out DateTime returnDt)
                    ? returnDt.ToString("yyyy-MM-dd HH:mm:ss")
                    : "N/A";

            Console.WriteLine($"{reader["RentalID"]} - Customer: {reader["CustomerName"]} ({reader["CustomerEmail"]}) - Vehicle: {reader["VehicleID"]} - Rent Date: {rentDate} - Return Date: {returnDate} - Total Cost: P{reader["TotalCost"]}");
            Console.WriteLine("-");
        }
        reader.Close();
        }



        static void ViewReservations(MySqlConnection connection)
        {
            string query = "SELECT * FROM Reservations";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("\nReservations:");
            while (reader.Read())
            {
                string pickupDate = reader["PickupDate"] != DBNull.Value
                    ? Convert.ToDateTime(reader["PickupDate"]).ToString("yyyy-MM-dd")
                    : "N/A";

                string returnDate = reader["ReturnDate"] != DBNull.Value
                    ? Convert.ToDateTime(reader["ReturnDate"]).ToString("yyyy-MM-dd")
                    : "N/A";

                decimal totalCost = reader["TotalCost"] != DBNull.Value
                    ? Convert.ToDecimal(reader["TotalCost"])
                    : 0;

                Console.WriteLine($"{reader["ReservationID"]} - Vehicle: {reader["VehicleID"]} - Customer: {reader["CustomerName"]}");
                Console.WriteLine($"  Pickup Date: {pickupDate} - Return Date: {returnDate} - Total Cost: ₱{totalCost}");
            }
            reader.Close();
        }



        static void ReserveVehicle(MySqlConnection connection)
        {
            Console.WriteLine("\n=== Available Vehicles for Reservation ===");
            string availableVehiclesQuery = "SELECT VehicleID, Model, Type, PricePerDay FROM Vehicles WHERE Available = 1";
            MySqlCommand availableVehiclesCommand = new MySqlCommand(availableVehiclesQuery, connection);
            MySqlDataReader availableVehiclesReader = availableVehiclesCommand.ExecuteReader();

            while (availableVehiclesReader.Read())
            {
                Console.WriteLine($"{availableVehiclesReader["VehicleID"]} - {availableVehiclesReader["Model"]} ({availableVehiclesReader["Type"]}) - ₱{availableVehiclesReader["PricePerDay"]}/day");
            }
            availableVehiclesReader.Close();

            Console.Write("\nEnter Vehicle ID to reserve: ");
            if (int.TryParse(Console.ReadLine(), out int vehicleId))
            {
                Console.Write("Enter Customer Name: ");
                string customerName = Console.ReadLine();

                Console.Write("Enter Customer Email: ");
                string customerEmail = Console.ReadLine(); 

                Console.Write("Enter Pickup Date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime pickupDate))
                {
                    Console.Write("Enter Return Date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime returnDate))
                    {
                        if (returnDate > pickupDate)
                        {
                            string priceQuery = "SELECT PricePerDay FROM Vehicles WHERE VehicleID = @VehicleID";
                            MySqlCommand priceCommand = new MySqlCommand(priceQuery, connection);
                            priceCommand.Parameters.AddWithValue("@VehicleID", vehicleId);

                            object result = priceCommand.ExecuteScalar();
                            if (result != null)
                            {
                                decimal pricePerDay = Convert.ToDecimal(result);
                                int days = (int)(returnDate - pickupDate).TotalDays;
                                decimal totalCost = days * pricePerDay;

                                string query = @"INSERT INTO Reservations 
                                (VehicleID, CustomerName, CustomerEmail, PickupDate, ReturnDate, TotalCost, ReservationDate) 
                                VALUES (@VehicleID, @CustomerName, @CustomerEmail, @PickupDate, @ReturnDate, @TotalCost, NOW());";

                                MySqlCommand command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@VehicleID", vehicleId);
                                command.Parameters.AddWithValue("@CustomerName", customerName);
                                command.Parameters.AddWithValue("@CustomerEmail", customerEmail);
                                command.Parameters.AddWithValue("@PickupDate", pickupDate);
                                command.Parameters.AddWithValue("@ReturnDate", returnDate);
                                command.Parameters.AddWithValue("@TotalCost", totalCost);

                                command.ExecuteNonQuery();

                                string updateQuery = "UPDATE Vehicles SET Available = 0 WHERE VehicleID = @VehicleID";
                                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                                updateCommand.Parameters.AddWithValue("@VehicleID", vehicleId);
                                updateCommand.ExecuteNonQuery();

                                Console.WriteLine($"\n✅ Vehicle reserved successfully!");
                                Console.WriteLine($"Customer: {customerName}");
                                Console.WriteLine($"Pickup Date: {pickupDate:yyyy-MM-dd}");
                                Console.WriteLine($"Return Date: {returnDate:yyyy-MM-dd}");
                                Console.WriteLine($"Total Cost: ₱{totalCost}");

                                // Send Email Confirmation
                                EmailService emailService = new EmailService();
                                string subject = "Reservation Confirmation - Car Rental Service";
                                string body = $"<h2>Reservation Confirmation</h2>" +
                                              $"<p>Dear {customerName},</p>" +
                                              $"<p>Your vehicle reservation has been confirmed.</p>" +
                                              $"<p><strong>Pickup Date:</strong> {pickupDate:yyyy-MM-dd}</p>" +
                                              $"<p><strong>Return Date:</strong> {returnDate:yyyy-MM-dd}</p>" +
                                              $"<p><strong>Total Cost:</strong> ₱{totalCost}</p>" +
                                              $"<p>Thank you for choosing G4 Car rental service!</p>";

                                emailService.SendEmail(customerEmail, subject, body);
                            }
                            else
                            {
                                Console.WriteLine("❌ Invalid Vehicle ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("❌ Return date must be after pickup date.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid return date format.");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Invalid pickup date format.");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid input.");
            }
        }

        static void AddVehicle(MySqlConnection connection)
        {
            Console.WriteLine("\n=== Add New Vehicle ===");

            Console.Write("Enter Model: ");
            string model = Console.ReadLine();

            Console.Write("Enter Type (Car/Van): ");
            string type = Console.ReadLine();

            Console.Write("Enter Price Per Day: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal pricePerDay))
            {
                string query = "INSERT INTO Vehicles (Model, Type, PricePerDay, Available) VALUES (@Model, @Type, @PricePerDay, 1)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Model", model);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@PricePerDay", pricePerDay);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("\n✅ Vehicle added successfully!");
                }
                else
                {
                    Console.WriteLine("❌ Failed to add vehicle.");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid price format.");
            }
        }


        static void DeleteVehicle(MySqlConnection connection)
        {
            DisplayVehicles(connection);

            Console.Write("\nEnter Vehicle ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int vehicleID))
            {
                string query = "DELETE FROM Vehicles WHERE VehicleID = @VehicleID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@VehicleID", vehicleID);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("✅ Vehicle deleted successfully!");
                }
                else
                {
                    Console.WriteLine("❌ Failed to delete vehicle. Vehicle ID not found.");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid input.");
            }
        }

       




    }
