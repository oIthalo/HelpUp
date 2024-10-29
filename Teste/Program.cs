using HelpUp.Domain.Entities;
using HelpUp.Domain.Enums;
using HelpUp.Domain.ValueObjects;

var _name = new Name("Instituto Esperança");
var _description = new Description("ONG focada em educação e apoio social.");
var _document = new Document(EDocumentType.CNPJ, "59.114.484/0001-42");
var _address = new Address("12345678", "SP", "São Paulo", "Centro", "Rua da paz", 123, "Próximo à praça central");
var _foundationDate = new FoundationDate(new DateTime(2010, 5, 15));
var _contactNumber = new PhoneNumber("(11) 98765-4321");
var _email = new Email("contato@institutoesperanca.org");
var _category = new Category("Educação e Apoio Social");
var _founder = new Name("Maria Silva");

var ong = new ONG(_name, _description, _document, _address, _foundationDate, _contactNumber, _email, _category, _founder);

foreach (var notification in ong.Notifications)
{
    Console.WriteLine($"Property: {notification.Key}, Message: {notification.Message}");
}