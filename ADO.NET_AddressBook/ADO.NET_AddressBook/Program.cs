ADO.NET_AddressBook.AddressBookRepo repo = new ADO.NET_AddressBook.AddressBookRepo();
Console.WriteLine("Enter your option to perform\n1. Create New Contact\n2. View the Contact Details\n3. Update the Details\n4. Delete the Details using name");
int input = Convert.ToInt32(Console.ReadLine());
switch (input)
{    
    case 1:
        repo.CreateNewContact();        
        repo.RetrieveDataFromDatabase();
        break;
    case 2:
        repo.RetrieveDataFromDatabase();
        break;
    case 3:
        repo.RetrieveDataFromDatabase();
        repo.UpdateRecordDetails();
        repo.RetrieveDataFromDatabase();
        break;
    case 4:
        repo.RetrieveDataFromDatabase();
        repo.DeleteAddressBookContact();
        repo.RetrieveDataFromDatabase();
        break;    
    default:
        Console.WriteLine("Invalid Input");
        break;
}