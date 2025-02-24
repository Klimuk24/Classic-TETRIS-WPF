using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    // BlockQueue - отвечающий за очередь блоков (т.е. выбор след. падающего блока в игре)
    public class BlockQueue
    {
        // Получение массива экземпляров всех видов блоков 
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        // Создание случайного объекта для реализации рандома
        private readonly Random random = new Random();

        public Block NextBlock { get; private set; }

        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        // Метод возвращающий новый случайный блок
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        // Метод обновляющий свойство NextBlock и подбирающий блок не схожий с предыдущим
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
