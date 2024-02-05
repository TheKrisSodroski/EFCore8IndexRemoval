// See https://aka.ms/new-console-template for more information
using ChildModel;
using EFCoreExtensions;
using Microsoft.EntityFrameworkCore;
using ParentModel;
using System.Reflection;

Console.WriteLine("Hello, World!");

List<Assembly> otherAssemblies = new List<Assembly>() { typeof(ParentClass).Assembly };

ExampleContext<ChildClass> context = new ExampleContext<ChildClass>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCoreExample", otherAssemblies);


string createScript = context.Database.GenerateCreateScript();

Console.WriteLine("The following create script should not have an index, yet for some reason it does.:");
Console.WriteLine(createScript);