using System;

namespace ElevatorApp
{
    // Перечисление состояний (как требуется в задании)
    public enum ElevatorState
    {
        STOPPED, // Стоит
        MOVING_UP, // Едет вверх
        MOVING_DOWN // Едет вниз
    }

    public class Elevator
    {
        // Свойства лифта
        public int CurrentFloor { get; private set; } = 1; // Текущий этаж 
        public int TotalFloors { get; set; } // Всего этажей
        public bool IsDoorOpen { get; private set; } = false; // Двери изначально закрыты

        public ElevatorState State { get; private set; } = ElevatorState.STOPPED;
        public string Message { get; private set; } = "Лифт готов к работе.";

        // Метод открытия дверей
        public void OpenDoor()
        {
            if (State != ElevatorState.STOPPED)
            {
                Message = "Нельзя открыть двери во время движения!";
            }
            else
            {
                IsDoorOpen = true;
                Message = "Двери открываются...";
            }
        }

        // Метод закрытия дверей
        public void CloseDoor()
        {
            IsDoorOpen = false;
            Message = "Двери закрываются.";
        }

        // Метод для подъёма вверх
        public void MoveUp()
        {
            // Проверка: Нельзя двигаться с открытыми дверями 
            if (IsDoorOpen)
            {
                Message = "Ошибка: Сначала закройте двери!";
                return;
            }

            // Проверка: Нельзя подниматься выше последнего этажа 
            if (CurrentFloor < TotalFloors)
            {
                State = ElevatorState.MOVING_UP;
                CurrentFloor++; // Увеличиваем этаж
                State = ElevatorState.STOPPED;
                Message = $"Лифт поднялся на {CurrentFloor} этаж.";
            }
            else
            {
                Message = "Вы уже на последнем этаже.";
            }
        }

        // Метод для спуска вниз
        public void MoveDown()
        {
            if (IsDoorOpen)
            {
                Message = "Ошибка: Сначала закройте двери!";
                return;
            }

            // Проверка: Нельзя опускаться ниже первого этажа 
            if (CurrentFloor > 1)
            {
                State = ElevatorState.MOVING_DOWN;
                CurrentFloor--; // Уменьшаем этаж
                State = ElevatorState.STOPPED;
                Message = $"Лифт опустился на {CurrentFloor} этаж.";
            }
            else
            {
                Message = "Вы уже на первом этаже.";
            }
        }
    }
}