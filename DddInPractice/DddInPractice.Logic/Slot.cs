﻿namespace DddInPractice.Logic
{
    public class Slot : Entity
    {
        public virtual Snack Snack { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal Price { get; set; }
        public virtual SnackMachine SnackMachine { get; protected set; }
        public virtual int Position { get; protected set; }

        protected Slot()
        {
        }

        public Slot(Snack snack, int quantity, decimal price, SnackMachine snackMachine, int position) : this()
        {
            Snack = snack;
            Quantity = quantity;
            Price = price;
            SnackMachine = snackMachine;
            Position = position;
        }
    }
}