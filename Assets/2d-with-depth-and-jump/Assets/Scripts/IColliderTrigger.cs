using System;

interface IColliderTrigger {
    void OnTrigger();
}

interface IPlaceOrder {
    void PlaceOrder(String food);
}

class PhoneOrder : IPlaceOrder {
    public void PlaceOrder(String food) {
        Console.WriteLine("Order placed for " + food);
    }
}

class InPersonOrder : IPlaceOrder {
    public void PlaceOrder(String food) {
        Console.WriteLine("Order placed for " + food);
    }
}

class WebOrder : IPlaceOrder {
    public void PlaceOrder(String food) {
        Console.WriteLine("Order placed for " + food);
    }
}

class PartyOrganizer {

    private String[] foods = {};
    public void OrderFood(IPlaceOrder order, String food) {
        order.PlaceOrder(food);
        foods[foods.Length] = food;
    }

    public void UglyOrderFood(String method, String food) {
        if (method == "Phone") {
            new PhoneOrder().PlaceOrder(food);
        } else if (method == "InPerson") {
            new InPersonOrder().PlaceOrder(food);
        } else if (method == "Web") {
            new WebOrder().PlaceOrder(food);
        }
    }
}

class Program {
    static void Main() {
        PartyOrganizer partyOrganizer = new PartyOrganizer();
        PhoneOrder phoneOrder = new PhoneOrder();
        InPersonOrder inPersonOrder = new InPersonOrder();
        partyOrganizer.OrderFood(phoneOrder, "Pizza");
        partyOrganizer.OrderFood(inPersonOrder, "Burger");
    }
}