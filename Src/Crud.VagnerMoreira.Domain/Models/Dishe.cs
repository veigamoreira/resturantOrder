namespace Crud.VagnerMoreira.Domain.Models
{
    public class Dishe : Base
    {

        public string OrderRequest { get; set; }
    }

    enum DysheType
    {
        entrée = 1,
        side = 2,
        drink = 3,
        dessert = 4,
    }


    enum DysheMorning
    {
        Eggs = 1,
        Toast = 2,
        Coffee = 3,
    }


    enum DysheNight
    {
        steak = 1,
        potato = 2,
        wine = 3,
        cake = 4,
    }

}
