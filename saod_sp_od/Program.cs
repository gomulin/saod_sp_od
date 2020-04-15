using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saod_sp_od
{
    class Node
    {
        public int value;
        public Node next;
        public Node(int x)
        {
            this.value = x;
        }

    }
    class LList //1 - опред список в котором ни одного узла
    {
        public Node head;
        public int Count;
        public LList()
        {
            //head = null;//def
        }
        public void AddLast(int x)//простейший медод который добав эл-т в конец списка
        {
            var toAdd = new Node(x);//создаём узел который ни к чему ни привязан
            if (head == null)
                head = toAdd;//если в спис ничего, то созд-ый узел и явл началом списка
            else // 2ой этап - если спис заполнен
            {
                Node current = head;//созд объект
                while (current.next != null)
                    current = current.next; //меняем данный объет на следующий, смещаем на нужную позицию
                current.next = toAdd;//дошел до конца и делаем toAdd

            }
            ++Count;

        }

        public void AddFirst(int x)//вставка в начало 
        {
            var toAdd = new Node(x);//создали объект который не связ со списком
            toAdd.next = head;

            head = toAdd;
            ++Count;
        }

        public void Clear()//garbage collector
        {
            head = null;
            Count = 0;
        }

        public void insert(int index, int x)//вставка "между"
        {
            if (head == null)
            {
                var toAdd = new Node(x);
                head = toAdd;
                ++Count;
            }
            else
            {
                if (index == 0)
                    AddFirst(x);
                else
                {
                    var toAdd = new Node(x);

                    Node current = head;
                    Node previous = head;


                    for (int i = 0; i < index && current != null; i++)
                    {
                        previous = current;
                        current = current.next;
                    }
                    previous.next = toAdd;
                    toAdd.next = current;
                    ++Count;
                }
            }
        }
        
        public void Remove(int index)
        {
            if(head != null)
            {
                if (index == 0)//в случае если удал начало
                {
                    head = head.next;
                    --Count;
                }
                else if(index < Count - 1)//-случай
                {
                    Node current = head;

                    for (int i = 0; i < index - 1 /*&& current != null*/; i++)
                    {
                        
                        current = current.next;
                    }
                    current.next = current.next.next;

                    --Count;
                }

                else if(index >= Count - 1)//удалить последний объект
                {
                    Node current = head;

                    for (int i = 0; i < index - 1 && current.next != null; i++)
                    
                        current = current.next;
                    current.next = null;
                    --Count;
                }
            }
        }

        public int this[int index]
        {
            get
            {
                Node current = head;//двигаемся 1 ссылкой
                for (int i = 0; i < index && current != null; i++)
                    current = current.next;
                return current.value;
            }
            set
            {
                Node current = head;
                for (int i = 0; i < index && current != null; i++)
                    current = current.next;
                current.value = value;
            }
        }
    }

    
    class MyQueue
    {
        public Node front;
        public Node rear;

        public  void enqueue(int x)//операция добавления
        {
            var toAdd = new Node(x);
            if (rear ==null)//если очередь пустая - добав в нач и в кон одновременно тк нач и кон очереди будут идентичны
            {
                front = rear = toAdd;
            }
            else//если оч не пустая, можно обойтись без счётчика
            {
                rear.next = toAdd;
                rear = toAdd;
            }
        }

        public void dequeue()//достать из очереди
        {
            if (front == null)//если оч пустая - выкат из метода
                return;

            Node temp = front;//сохран предыд нач-ло оч-ди
            front = front.next; //сдвиг начала на узл вперёд

            if (front == null)
                rear = null;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var lst = new MyQueue();
            lst.enqueue(1);//1 - FIFO
            lst.enqueue(2);
            lst.enqueue(3);
            lst.enqueue(4);

            Console.WriteLine(lst.front.value);//1 в очередч


            lst.dequeue();//убрали 1
            lst.dequeue();//2
            lst.enqueue(5);//добав 5
            lst.dequeue();//3
            
            lst.dequeue(); //(4) достали - получили 2,    5
            Console.WriteLine(lst.front.value);

            /*var lst = new LList();
            lst.AddLast(1);
            lst.AddLast(2);
            lst.AddLast(3);
            lst.AddFirst(0);
            /*Console.WriteLine(lst.head.value);
            Console.WriteLine(lst.head.next.value);
            Console.WriteLine(lst.head.next.next.value);
            Console.ReadKey();

            //0123
            lst.insert(2, 4);

            //lst[2] = 5;// 5 на 2ую позицию

            for (int i = 0; i != lst.Count; i++)
            {
                Console.Write(lst[i] + " -> ");//чтобы применить индекс-цию нужна перегрузка
            }
            Console.WriteLine("null ");

            lst.Remove(2);

            for (int i = 0; i != lst.Count; i++)
            {
                Console.Write(lst[i] + " -> ");//чтобы применить индекс-цию нужна перегрузка
            }


            Console.WriteLine("null ");*/
            Console.ReadKey();
        }

    }
} 
    

