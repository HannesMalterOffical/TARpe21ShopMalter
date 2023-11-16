namespace TARpe21ShopMalter.Models.Car
{
    public class CarIndexViewModel
    {
        public Guid Id { get; set; } // unique id
        public string bodyType { get; set; } // WHat type of car is it, sedan, SUV ect
        public string carMake { get; set; } // What make the car is
        public string bodyColor { get; set; } // Car body color
        public string steeringWheeleLocation { get; set; } // Where the Steering wheele is located
        public string Model { get; set; } // model of the car
        public int madeInYear { get; set; } // year it was made in
        public int price { get; set; } // what the car costs
        public int powerkW { get; set; } // engine power in kilow Watts
        public string fuleType { get; set; } // what type of fuel the car useses
        public string transmission { get; set; } // what sort of transmission the car has

        public bool IsCarUsed { get; set; } // is the car used or not
        public bool IsCarSold { get; set; } // is the car sold

        //database only properties

        public DateTime CreatedAt { get; set; } //when entry was added to the database
        public DateTime ModifiedAt { get; set; } //when wwas entry modified in the database
    }
}
