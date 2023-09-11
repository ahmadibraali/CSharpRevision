namespace Business
{
    public class Departement
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManagerSSN { get; set; }

        public List<Employee> Employees { get; set; }
    }
}