using System;
namespace Start
{
    
        public class Credit  //Это аннуитетный?    
        {
            //todo разобраться с полями и модификаторами доступа
            //todo ТеСтИкИ попытаться

            public string Name { get; set; }  //название 
            
            public RealCard Aktiv { get; set; }  //место списания
            public double AktivsMoney;

            public double MonthlyRate;  //месячная ставка/MonthlyRate = AnnualRate (ставка по кредиту) /100 *12)
            public double AnnualRate;   //годовая ставка

            public double Sum;
            public double Duty;  //долг на данный момент

            public int Months;
            public int WasMonths;  //оплатили месяцев
            public int WiilMonths;  //осталось платить

            public DateTime DateOfTakingCredit;



            //конструктор
            //todo все ли аргументы нужны?
            public Credit(string name, RealCard aktiv, double annualRate, double sum, int months, DateTime dateOfTakingCredit)
            {
                Name = name;
              
                Aktiv = aktiv;
                AnnualRate = annualRate;
                Sum = sum;
                Months = months;
                DateOfTakingCredit = dateOfTakingCredit;
            }


            //метод для добавления кредита ???




            //метод для ежемесячной оплаты
            public void WritingOffMoney(string Card)  //todo подтянуть актив/понять откуда/подавать на вход карту
            {
                if (Aktiv.Balance > GetMonthlyPayment())
                {
                Aktiv.Balance -= (int)GetMonthlyPayment();
                }
                else
                {
                    throw new Exception("На активе не достаточно средств");
                }

            }

            //посмотреть сколько уже заплатил  ???????
            public double WasPay()
            {
                double wasPay = GetMonthlyPayment() * WasMonths;
                return wasPay;
            }

            //сколько переплатил по % ???

            //ежемесячный платеж размер
            public double GetMonthlyPayment()
            {
                double monthlyRate = GetMonthlyRate();
                double MonthlyPayment = Duty * (monthlyRate / (1 - Math.Pow((1 + monthlyRate), -Months)));
                return MonthlyPayment;
            }


            public double GetMonthlyRate()//месячная ставка/MonthlyRate = AnnualRate (ставка по кредиту) /100 *12)
            {
                double monthlyRate = AnnualRate / 100 * 12;
                return monthlyRate;
            }
        }
    }

