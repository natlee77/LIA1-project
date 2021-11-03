CREATE TABLE Users ( 
	Id int not null identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Ssn char(12) not null,
	Email varchar(100) not null,
	Phonenumber varchar(15) not null,
	Uhash varbinary(max) not null,
	Usalt varbinary(max) not null 
)
GO

CREATE TABLE UserMessages (
	Id int not null identity(1,1) primary key,
	Title nvarchar(50) not null,
	Message nvarchar(max) not null,
	MessageDate datetime not null,
	UserId int not null references Users(Id)
)

CREATE TABLE Bills (
	Id int not null identity(1,1) primary key,
	Price decimal not null,
	BillPeriod char(50) not null,
	BillExpire datetime not null,
	UserId int not null references Users(Id)
)

CREATE TABLE ParkingLots (
	Id int not null identity(1,1) primary key,
	[Address] nvarchar(100) not null,
	AvailableLots int not null,
	TotalLots int not null
)

CREATE TABLE ParkingCategories (
	Id int not null identity(1,1) primary key,
	Price decimal null,
	ParkingCategory nvarchar(50) not null,
	ParkingLots int not null references ParkingLots(Id)
)

CREATE TABLE ContractApartments (
	Id int not null identity(1,1) primary key,
	[Address] nvarchar(100) not null,
	City nvarchar(50) not null,
	ApartmentNumber char(4) not null,
	Price decimal not null,
	StartDate datetime not null,
	ExpireDate datetime null,
	UserId int not null references Users(Id)
)

CREATE TABLE ContractParkings (
	Id int not null identity(1,1) primary key,
	[Address] nvarchar(100) not null,
	City nvarchar(50) not null,
	LotNumber char(4) not null,
	Price decimal not null,
	StartDate datetime not null,
	ExpireDate datetime null,
	ParkingCategory int not null references ParkingCategories(Id),
	UserId int not null references Users(Id)
)

CREATE TABLE LaundryRooms (
	Id int not null identity(1,1) primary key,
	[Address] nvarchar(100) not null,
	
)
 
CREATE TABLE LaundryBookings (
	Id int not null identity(1,1) primary key,
	BookingDate datetime null,
	BookingAvailable bit not null,
	LaundryRoom int not null references LaundryRooms(Id),
	UserId int not null references Users(Id)
)

CREATE TABLE ErrorReport (
	Id int not null identity(1,1) primary key,
	[Description] nvarchar(max) not null,
	ErrorDate datetime not null,
	UserId int not null references Users(Id)
)