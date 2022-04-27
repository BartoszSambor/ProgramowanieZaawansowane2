using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KomisBeta
{
    public enum Body
    {
        Coupe,
        Combi,
        Sedan,
        SUV
    }

    public enum Fuel
    {
        Gas,
        Diesel,
        LPG
    }

    public class Car   
    {
        public Car(string brand, string model, Body body, Fuel fuel, int year, int mileage, int price, Image image = null, string filePath = null)
        {
            this.brand = brand;
            this.model = model;
            this.body = body;
            this.fuel = fuel;
            this.year = year;
            this.mileage = mileage;
            this.price = price;
            if (image == null)
                this.image = Properties.Resources.CarDefault;
            else
                this.image = image;
            if (filePath != null)
                this.filePath = filePath;
        }

        public string brand { get; private set; }
        public string model { get; private set; }
        public Body body { get; private set; }
        public Fuel fuel { get; private set; }
        public int year { get; private set; }
        public int mileage { get; private set; }
        public int price { get; private set; }
        public Image image { get; private set; }

        public string filePath { get; private set; }

    public string ToCSV()
        {
            return (
                brand + ", " +
                model + ", " +
                body + ", " +
                fuel + ", " +
                year + ", " +
                mileage + ", " +
                price + ", " + 
                filePath
                );
        }

        public string SaveImage()
        {
            filePath = "images/"+Path.GetRandomFileName()+".png";
            image.Save(filePath);
            return filePath;
        }

        public void LoadImage()
        {

        }


    }
}
