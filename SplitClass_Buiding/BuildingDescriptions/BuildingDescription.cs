using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.BuildingDescriptions
{
    internal class BuildingDescription
    {
        private readonly Guid _uniqueBuildingNumber;
        private double _height;  
        private uint _numberOfStoreys;
        private uint _numberOfApartments;
        private int _entrances;

        /// <summary>
        ///уникальный номер здания
        /// </summary>
        public Guid UniqueBuildingNumber
        {
            get { return _uniqueBuildingNumber; }
            init { _uniqueBuildingNumber = value; }
        }
        /// <summary>
        /// высота
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        /// <summary>
        /// этажность
        /// </summary>
        public uint NumberOfStoreys
        {
            get { return _numberOfStoreys; }
            set { _numberOfStoreys = value; }
        }
        /// <summary>
        /// Кол-во квартир
        /// </summary>
        public uint NumberOfApartments
        {
            get { return _numberOfApartments; }
            set { _numberOfApartments = value; }
        }

        /// <summary>
        /// подъезд
        /// </summary>
        public int Entrances
        {
            get { return _entrances; }
            set { _entrances = value; }
        }

        public BuildingDescription()
        {
            
        }

        public BuildingDescription(ref int height, ref int floors, ref int apartments, ref int entrances)
        {
            if (height <= 0 || floors <= 0 || apartments <= 0 || entrances <= 0)
            {
                throw new Exception("Ни один параметр здания не может быть равен нулю либо быть меньше нуля");
            }
            UniqueBuildingNumber = Guid.NewGuid();
            _height = height;
            _numberOfStoreys = (uint)floors;
            _numberOfApartments =(uint) apartments;
            _entrances = entrances;
        }

        /// <summary>
        /// Изменение высоты дома
        /// </summary>
        public void ChangeHeight(ref double newHeight)
        {
            if (newHeight <= 0)
            {
                throw new Exception("Высота здания должна быть больше нуля");
            }
            _height = newHeight;
        }

        /// <summary>
        /// Изменение числа этажей
        /// </summary>
        public void ChangeStoreysCount(int newCount)
        {
            if (newCount <= 0)
            {
                throw new Exception("Кол-во этажей здания должно быть больше нуля");
            }
            _entrances = newCount;
        }

        /// <summary>
        /// Изменение числа квартир
        /// </summary>
        public void ChangeApartmentCount(ref int newCount)
        {
            if (newCount <= 0)
            {
                throw new Exception("Кол-во квартир в здании должно быть больше нуля");
            }
            _numberOfApartments = (uint)newCount;
        }

        /// <summary>
        /// Изменение числа подъездов
        /// </summary>
        public void ChangeEntranceCount(ref int newCount)
        {
            if (newCount <= 0)
            {
                throw new Exception("Кол-во подъездов в здании должно быть больше нуля");
            }
            _entrances =newCount;
        }

     
        /// <summary>
       /// Вычисление высоты одного этажа
        /// </summary>
        public double GetFloorHeight
        {
            get
            {
                CheckCorrectData();
                return _height / _numberOfStoreys;
            }
        }


        /// <summary>
        /// Вычисление количества квартир на этаже
        /// </summary>
        public uint CountFloor
        {
            get {
                CheckCorrectData();
                return _numberOfApartments % _numberOfStoreys > 0
                ? _numberOfApartments / (_numberOfStoreys + 1)
                : _numberOfApartments / _numberOfStoreys; }
        }

        private void CheckCorrectData()
        {
            if (_height <= 0 || _numberOfStoreys <= 0 || _numberOfApartments <= 0 || _entrances <= 0)
            {
                throw new Exception("Вычисление невозможно. Параметры дома заданы неверно.");
            }
        }

        public override string ToString()
        {
            return $"id: {_uniqueBuildingNumber},\n" +
                   $"Высота здания: {_height} м,\n" +
                   $"Кол-во квартир: {_numberOfApartments},\n" +
                   $"Кол-во этажей: {_numberOfStoreys},\n" +
                   $"Кол-во подъездов: {_entrances}.";
        }
    }
}
