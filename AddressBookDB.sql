UC1: Creating Address Book Service DB
CREATE DATABASE AddressBook;
use AddressBook;

UC2: Create Address book table
Create Table Address_Book (ID INT IDENTITY(1,1) PRIMARY KEY, FirstName VARCHAR(150), LastName VARCHAR(150), 
Address VARCHAR(150), City VARCHAR(150), State VARCHAR(150), ZipCode int, PhoneNumber bigint, Email VARCHAR(150));

UC3: Inserting Details into Address Book
INSERT INTO Address_Book( FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email ) VALUES
( 'Reshma', 'Rose', '49/A-62', 'Kurnool', 'AndhraPradesh', 234234, 2342342342, 'reshma@gmail.com' ),
( 'Vahidha', 'D', '4/6A-23', 'Vizak', 'AndhraPradesh', 134234, 6242342342, 'vahidha@yahoo.com' ),
( 'Basith', 'R', '49-A/28', 'Hyd', 'Telangana', 567234, 4567842342, 'basith@gmail.com' );
SELECT * FROM Address_Book;

UC4: Edit Existing person details using their name
UPDATE Address_Book SET Address='65-A/5',PhoneNumber=9085632147 where FirstName='Vahidha';

UC5: Delete a Person using Person Name
DELETE FROM Address_Book WHERE FirstName= 'Vahidha';

UC6: Get details using city or state name
SELECT * FROM Address_Book WHERE City='Hyd' OR State='AndhraPradesh';

UC7: Size of Address book by City or State
SELECT COUNT(*) FROM Address_Book WHERE City='Kurnool' AND State='AndhraPradesh';
SELECT COUNT(*) FROM Address_Book WHERE City='Hyd'

INSERT INTO Address_Book( FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email ) VALUES
( 'Vahidha', 'D', '4/6A-23', 'Vizak', 'AndhraPradesh', 134234, 6242342342, 'vahidha@yahoo.com' );

UC8: Data in Alphabetical order using city
SELECT FirstName, City FROM Address_Book ORDER BY City ASC;
SELECT FirstName, City FROM Address_Book ORDER BY City DESC;

UC9: Add Type to Identify
ALTER TABLE Address_Book ADD Type VARCHAR(150);
UPDATE Address_Book set Type='Family' where FirstName = 'Reshma' or FirstName = 'Basith';
UPDATE Address_Book set Type='Friends' where FirstName = 'Vahidha';
SELECT ID, Type, FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email FROM Address_Book;

UC10: Count by Type
SELECT COUNT(*) Family_Count FROM Address_Book WHERE Type='Family'
SELECT COUNT(*) Friends_Count FROM Address_Book WHERE Type='Friends'

UC11: Add Person to both Friend and Family
INSERT INTO Address_Book( FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email, Type ) VALUES
( 'Vali', 'D', '4/A-29', 'Vizak', 'AndhraPradesh', 231234, 2341142342, 'vali@gmail.com', 'Friends' ),
( 'Khajabi', 'D', '4A/6-3C', 'Kurnool', 'AndhraPradesh', 134254, 5242342342, 'khajabi@yahoo.com', 'Family' )
SELECT * FROM Address_Book;

UC12: Creating ER-Diagram
CREATE TABLE Type_Contacts(
Type_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
TYPE_Name VARCHAR(25) NOT NULL)

INSERT INTO Type_Contacts VALUES('Family'),('Friends'),('Colleagues')
SELECT * FROM Type_Contacts
CREATE TABLE Address_Contacts(
CONTACT_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstName VARCHAR(25) NOT NULL,
LastName VARCHAR(25) NOT NULL,
Address VARCHAR(100) NOT NULL,
City VARCHAR(25) NOT NULL,
State VARCHAR(25) NOT NULL,
ZipCode FLOAT NOT NULL,
Email VARCHAR(50) NOT NULL,
TYPE_ID INT NOT NULL)
INSERT INTO Address_Contacts VALUES('Rose','T','6/72','Hyd','Telangana',530045,'rose@gmail.com',1)
INSERT INTO Address_Contacts VALUES('Violet','M','6/89','Vijayawada','AndhraPradesh',521329,'violet@gmail.com',2)
INSERT INTO Address_Contacts VALUES('Sita','Kalla','9/86','Vizag','Andhra Pradesh',594521,'sita@gmail.com',2)
INSERT INTO Address_Contacts VALUES('Tarun','Namala','9/76','Sinhanur','Karnataka',665438,'tarun@gmail.com',1)
INSERT INTO Address_Contacts VALUES('Ramesh','Dundigala','6/89','Chennai','Tamil Nadu',986321,'ramesh@gmail.com',3)
INSERT INTO Address_Contacts VALUES('Harsha','Sridarvalli','8/54','Ongole','Andhra Pradesh',524321,'harsha@gmail.com',2)
INSERT INTO Address_Contacts VALUES('Radha','saragadam','6/72','Coimbatore','Tamil Nadu',532187,'radha@gmail.com',1)
SELECT * FROM Address_Contacts

 ---- Creating PhoneContacts Table

CREATE TABLE Phone_Contacts
(Contact_ID INT NOT NULL,
FirstName VARCHAR(25) NOT NULL,
PhoneNo1 FLOAT NOT NULL,
PhoneNo2 FLOAT NULL)
INSERT INTO Phone_Contacts VALUES(1,'Rose',1111261319,7554865303)
INSERT INTO Phone_Contacts VALUES(2,'Violet',2220123456,7689054321)
INSERT INTO Phone_Contacts VALUES(4,'Sita',2223217890,8906745123)
INSERT INTO Phone_Contacts VALUES(5,'Harsha',2227564231,7908645231)
INSERT INTO Phone_Contacts (Contact_ID,FirstName,PhoneNo1) VALUES(6,'Aarna',2229054123)
INSERT INTO Phone_Contacts VALUES(7,'Lakshmi',7222654321,2225321405)
INSERT INTO Phone_Contacts VALUES(8,'Radha',3336672345,4445428901)
SELECT * FROM Phone_Contacts

ALTER TABLE Address_Contacts ADD CONSTRAINT FK_Type_Contacts FOREIGN KEY(Type_ID) REFERENCES Type_Contacts(Type_ID) ON DELETE CASCADE ON UPDATE CASCADE
ALTER TABLE Phone_Contacts ADD CONSTRAINT FK_Phone_Contacts FOREIGN KEY(Person_ID) REFERENCES Address_Contacts(CONTACT_ID) ON DELETE CASCADE ON UPDATE CASCADE
ALTER TABLE Phone_Contacts ADD Person_ID INT

UC13: Group By Usage

SELECT * FROM Address_Contacts WHERE City = 'Vizag'
SELECT * FROM Address_Contacts WHERE STATE = 'Andhra Pradesh'

SELECT CITY, COUNT(CITY) AS Address_Contacts FROM ADDRESS_BOOK GROUP BY City
SELECT STATE, COUNT(STATE) AS Address_Contacts FROM ADDRESS_BOOK GROUP BY State

SELECT * FROM Address_Contacts WHERE City = 'Hyd' ORDER BY FirstName

SELECT TYPE_Name,COUNT(TYPE_Name) FROM Type_Contacts CT INNER JOIN Address_Contacts CA ON CT.Type_ID = CA.Type_ID GROUP BY TYPE_Name
SELECT TYPE_Name,CA.FirstName,PhoneNo1 FROM Type_Contacts CT INNER JOIN Address_Contacts CA ON CT.Type_ID = CA.Type_ID INNER JOIN Phone_Contacts CP ON CA.CONTACT_ID = CP.CONTACT_ID