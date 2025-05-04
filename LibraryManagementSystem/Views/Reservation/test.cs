/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/

     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*//*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
/*
This file defines the data structures and ViewModel used to manage and display reservation data in an ASP.NET Razor view.

1. The `ReservationsPagerViewModel` class:
   - Acts as a container for a list of `Reservation` objects.
   - This ViewModel is passed to the Razor page to provide the data needed for rendering.

2. The `Status` enum:
   - Represents different states that a reservation can be in.
   - Includes: 
     - Waiting: Reservation is active and waiting to be collected.
     - Expired: The reservation was not collected in time.
     - Collected: The reservation has been successfully picked up.
     - Cancelled: The reservation was canceled by the user or system.
     - None: A default or unknown state.

3. The `Reservation` class:
   - Represents a single reservation record.
   - Properties include:
     - Id: A unique identifier for the reservation.
     - BookName: Title of the book that has been reserved.
     - MemberName: The user who made the reservation.
     - ReservationDate: The date the reservation was created.
     - ExpiryDate: The deadline for collecting the reserved item.
     - Status: Indicates the current state of the reservation, using the `Status` enum.

4. The Razor view:
   - Accepts a `ReservationsPagerViewModel` as its model.
   - Renders a table to display all reservation entries.
   - Table headers show ID, Book Title, Member Name, Reservation Date, Expiry Date, Status, and Actions.
   - For each reservation:
     - Displays the properties in respective columns.
     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/

     - Formats the date values for better readability.
     - Uses a switch statement to visually differentiate each reservation status using Font Awesome icons:
       - Waiting: Hourglass icon with a warning color.
       - Expired: Red 'X' icon.
       - Collected: Green checkmark icon.
       - Cancelled: Grey ban icon.
       - None/Default: Question mark icon.
   - Provides a delete button in the last column, which links to an action that handles reservation deletion.

Overall, this code sets up the model and the view logic for listing reservations in a stylized HTML table in an ASP.NET MVC application.
*/
