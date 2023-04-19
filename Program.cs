using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_19._04._2023_2_
{
   
        enum Month
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }
        class myMeterReader
        {
            int waterCount;
            public int WaterCount
            {
                get
                {
                    return waterCount;
                }
                set
                {
                    waterCount = value;
                }
            }
            public myMeterReader(int _number)
            {
                waterCount = _number;
            }
            public string convert2Str()
            {
                string _tmp = waterCount.ToString();
                while (_tmp.Length < 8)
                {
                    _tmp = "0" + _tmp;
                }
                return _tmp;
            }
        }
        struct myMeterReader02
        {
            public myMeterReader Cold;
            public myMeterReader Hot;
        }
        class myCounter
        {
            int _min = 0, _max = 99999999;
            List<myMeterReader02> myBillList = new List<myMeterReader02>();
            public myCounter(int _cold, int _hot)
            {
                if (_cold >= _min || _cold <= _max)
                {
                    if (_hot >= _min || _hot <= _max)
                    {
                        myMeterReader02 myMR02;
                        myMR02.Cold = new myMeterReader(_cold);
                        myMR02.Hot = new myMeterReader(_hot);
                        myBillList.Add(myMR02);
                    }
                }
            }
            public bool addMetric(int _cold, int _hot)
            {
                bool result = false;
                int _lastElement = myBillList.Count;
                if (myBillList[_lastElement - 1].Cold.WaterCount <= _cold)
                {
                    if (myBillList[_lastElement - 1].Hot.WaterCount <= _hot)
                    {
                        myMeterReader02 myMR02;
                        myMR02.Cold = new myMeterReader(_cold);
                        myMR02.Hot = new myMeterReader(_hot);
                        myBillList.Add(myMR02);
                        result = true;
                    }

                }
                return result;
            }
            public List<myMeterReader02> getValues()
            {
                return myBillList;
            }
        }
        internal class Program
        {
            
        
                static void addDataFromArr()
            {

            }
                static void Main(string[] args)
                {
                    int[,] counterArr = new int[,] { { 12, 10 }, { 11, 10 }, { 14, 13 }, { 15, 21 }, { 16, 20 } };
                    int _row = counterArr.GetUpperBound(0); // количество строк, "пар"
                    int _column = counterArr.Length / _row; // количество столбцов, 2 в нашем случае
                    int _cold = 0, _hot = 0;
                    myCounter _meterReader = new myCounter(0, 0);
                    for (int i = 0; i < _row; i++)
                    {
                        for (int j = 0; j < _column; j++)
                        {
                            if (j % 2 == 0)
                            {
                                _cold = counterArr[i, j];
                                Console.Write("холодная = " + counterArr[i, j] + " ");
                            }
                            else
                            {
                                _hot = counterArr[i, j];
                                Console.Write("горячая = " + counterArr[i, j] + ".");
                            }
                        }
                        Console.WriteLine($"Пытаюсь добавить значение холодной {_cold} и горячей {_hot} воды");
                        if (_meterReader.addMetric(_cold, _hot))
                        {
                            Console.WriteLine($"Добавлено значение холодной {_cold} и горячей {_hot} воды");
                        }
                        else
                        {
                            Console.WriteLine($"Значение холодной {_cold} и горячей {_hot} воды не добавлено");
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("\n\nИтог:");
                    int _month = 1;
                    string myMonth;
                    _meterReader.getValues().RemoveAt(0); // Удаляем следствие работы конструктора - 1 элемент
                    foreach (var item in _meterReader.getValues())
                    {
                        myMonth = Enum.GetName(typeof(Month), _month);
                        Console.WriteLine($"За {myMonth} \t холодная = {item.Cold.convert2Str()} горячая = {item.Hot.convert2Str()}");
                        _month++;
                    }
                }
            } 
        }
