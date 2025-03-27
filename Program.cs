// Задачи на работу мне лень писать

//Таска 1 : Касса в магазине
using System;
using System.Collections.Generic;

public class CashRegister
{
    public List<Product> cart = new List<Product>();
    public void AddProductToCart(Product product, int amount)
    {
        if (product.quantity >= amount)
        {
            Product cartProduct = new Product { name = product.name, price = product.price, quantity = amount };
            cart.Add(cartProduct);
            product.quantity -= amount; 
        }
        else
        {
            Console.WriteLine("Недостаточно товара на складе: " + product.name);
        }
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (Product product in cart)
        {
            total += product.price * product.quantity;
        }
        return total;
    }

    public void Checkout()
    {
        double total = CalculateTotal();
        Console.WriteLine("Итоговая сумма: " + total);
        cart.Clear(); 
    }
}

public class Shop
{
    public static void Main(string[] args)
    {
        Product product1 = new Product { name = "Товар 1", price = 100, quantity = 10 };
        Product product2 = new Product { name = "Товар 2", price = 200, quantity = 5 };

        CashRegister cashRegister = new CashRegister();

        cashRegister.AddProductToCart(product1, 2);
        cashRegister.AddProductToCart(product2, 1);

        cashRegister.Checkout();

        Console.WriteLine("Остаток товара " + product1.name + ": " + product1.quantity);
        Console.WriteLine("Остаток товара " + product2.name + ": " + product2.quantity);
    }
}

//Таска 2: геометрические фигуры
using System;
using System.Collections.Generic;

public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}

public class Rectangle : Shape
{
    public double width;
    public double height;
    public override double CalculateArea()
    {
        return width * height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (width + height);
    }
}

public class Circle : Shape
{
    public double radius;

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }
}

public class Triangle : Shape
{
    public double side1;
    public double side2;
    public double side3;

    public override double CalculateArea()
    {
        double s = (side1 + side2 + side3) / 2;
        return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
    }

    public override double CalculatePerimeter()
    {
        return side1 + side2 + side3;
    }
}

public class Geometry
{
    public static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Rectangle { width = 5, height = 10 });
        shapes.Add(new Circle { radius = 3 });
        shapes.Add(new Triangle { side1 = 3, side2 = 4, side3 = 5 });

        foreach (Shape shape in shapes)
        {
            Console.WriteLine("Площадь: " + shape.CalculateArea());
            Console.WriteLine("Периметр: " + shape.CalculatePerimeter());
        }
    }
}
//меня хватило только на это

//Таска 3: авиабилетики
using System;
using System.Collections.Generic;

public class Passenger
{
    public string name;
    public string passportNumber;
}

public class Flight
{
    public string flightNumber;
    public string destination;
    public List<Passenger> passengers = new List<Passenger>();

    public void AddPassenger(Passenger passenger)
    {
        passengers.Add(passenger);
    }

    public bool HasPassenger(string passportNumber)
    {
        foreach (Passenger passenger in passengers)
        {
            if (passenger.passportNumber == passportNumber)
            {
                return true;
            }
        }
        return false;
    }
}

public class Airline
{
    public static void Main(string[] args)
    {
        Flight flight = new Flight { flightNumber = "FL123", destination = "Москва" };

        Passenger passenger1 = new Passenger { name = "Иванов", passportNumber = "123456" };
        Passenger passenger2 = new Passenger { name = "Петров", passportNumber = "789012" };

        flight.AddPassenger(passenger1);
        flight.AddPassenger(passenger2);
        Console.WriteLine("Пассажир с паспортом 123456 на рейсе: " + flight.HasPassenger("123456"));
        Console.WriteLine("Пассажир с паспортом 345678 на рейсе: " + flight.HasPassenger("345678"));
    }
}


//таска 4: космо-миссия
using System;
using System.Collections.Generic;

public class Astronaut
{
    public string name;
    public string role;
}

public class Rocket
{
    public string name;
    public int fuel;
    public List<Astronaut> crew = new List<Astronaut>();

    public void Launch()
    {
        if (fuel >= 100) 
        {
            Console.WriteLine("Запуск ракеты " + name + "!");
            Console.WriteLine("Экипаж:");
            foreach (Astronaut astronaut in crew)
            {
                Console.WriteLine(astronaut.name + " - " + astronaut.role);
            }
        }
        else
        {
            Console.WriteLine("Недостаточно топлива для запуска!");
        }
    }
}

public class SpaceMission
{
    public static void Main(string[] args)
    {
        Rocket rocket = new Rocket { name = "Союз", fuel = 150 };

        Astronaut astronaut1 = new Astronaut { name = "Гагарин", role = "Пилот" };
        Astronaut astronaut2 = new Astronaut { name = "Титов", role = "Инженер" };

        rocket.crew.Add(astronaut1);
        rocket.crew.Add(astronaut2);

        rocket.Launch();
    }
}
