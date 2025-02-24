using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    // Block - абстрактный класс для представления всех остальных блоков
    public abstract class Block
    {
        // Расположение фигуры в двумерном пространстве 
        protected abstract Position[][] Tiles { get; }
        
        // Начальное смещение фигуры (место появления фигуры)
        protected abstract Position StartOffset { get; }

        // Целочисленный индефикатор для различения фигур 
        public abstract int Id { get; }

        // Текущее вращение фигуры
        private int rotationState;

        // Текущее смещение позиции фигуры
        private Position offset;

        // Конструктор начального смещения позиции фигуры
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        // Метод вращения фигуры по часовой на 90 град.
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        // Метод вращения фигуры против часовой на 90 град.
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }
        
        // Метод перемещающий фигуру на заданное кол.во строк и столбцов
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        // Метод сброса вращения и позиционирования фигуры в нач.положении
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}