# shipping-app
A shipping company receives packages at its headquarters, which functions as its shipping hub. After receiving the packages the company ships them to a distribution center in one of the following states: Alabama, Florida, Georgia, Kentucky, Mississippi, North Carolina, South Carolina, Tennessee, West Virginia or Virginia. The company needs an application to track the packages that pass through its shipping hub. The application generates a package ID number for each package that arrives at the shipping hub, when the user clicks the application’s Scan New Button. Once a package has been scanned, the user should be able to enter the shipping address for the package. The user should be able to navigate through the list of scanned packages by using &lt;BACK or NEXT> Buttons and by viewing a list of all packages destined for a particular state.

#This Application is expected to work as described below:

Scanning a new package: 
Click the “Scan New” button. The application displays a package ID number, the current date and time in “Arrived at:” textbox, enables the TextBoxes and allows the user to enter the package information (address)
Adding a package to the list of packages: Click in the “Address” TextBox to transfer the focus of the application to that field, and enter data. Continue using Tab to transfer focus to each field and finish address entry (City, select state using ComboBox, etc.). Then click the “Add” button to add the package to the application’s ArrayList or List<>.
Removing, editing, and browsing packages: The application’s NEXT > and <BACK buttons allow the user to navigate the list of the packages. The REMOVE button allows the user to delete packages, and the EDIT button allows the user to update a particular package’s information.
Viewing all packages going to a state: The ComboBox on the right side of the application allows the user to select a state. When a state is selected, all of the package ID numbers of packages destined for that state are displayed in the ListBox  (below the state comboBox at the right hand side of the Figure)

