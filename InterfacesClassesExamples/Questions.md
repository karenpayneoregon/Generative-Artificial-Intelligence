1. Create a public crud interface named IBase under Program.cs
1. create a public class named Customer which implements IBase with the following properties, Id, FirstName, LastName, Email and BirthDate as DateOnly

create a public class named Customer which implements IBase with the following properties, Id, FirstName, LastName, Email and BirthDate as DateOnly and implement INotifyPropertyChanged for each property

Create a generic language extension method with a constraint for IComparable<T> and struct which determines if a value is between two values


1. Create a public crud interface named IBase under Program.cs
1. create a public class named Customer which implements IBase with the following properties, Id, FirstName, LastName, Email and BirthDate as DateOnly and implement INotifyPropertyChanged for each property

---
Kind of works

create a public class named Customer which implements @workspace #file: Interfaces\IBase.cs with the following properties, Id, FirstName, LastName, Email and BirthDate as DateOnly and implement INotifyPropertyChanged for each property

---
Works

Create a public crud generic interface named IBase under Program.cs. create a public class named Customer which implements IBase with the following properties, Id, FirstName, LastName, Email and BirthDate as DateOnly and implement INotifyPropertyChanged for each property

---
Works but needs assistance from R#

- Do it in Program.cs than in Works.cs, not sync vs async

Create a public crud generic interface named IBase with a contraint on T. create a public class named Customer which implements IBase with the following properties, Id, FirstName, LastName, Email and BirthDate as DateOnly and implement INotifyPropertyChanged for each property