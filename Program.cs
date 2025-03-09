public class DoubleLinkedListItem
{
    public DoubleLinkedListItem previous;
    public DoubleLinkedListItem next;
    public int value;
    public DoubleLinkedListItem(int value)
    {
        this.value = value;
        this.previous = null;
        this.next = null;
    }
}

public class DoubleLinkedList
{
    private DoubleLinkedListItem start;
    private DoubleLinkedListItem end;
    public DoubleLinkedList()
    {
        start = null;
        end = null;
    }
    public DoubleLinkedList(int length)
    {
        for (int i = 0; i < length; i++)
        {
            var item = new DoubleLinkedListItem(i+1);
            if (start == null)
            {
                start = item;
                end = item;
            }
            else
            {
                end.next = item;
                item.previous = end;
                end = item;
            }
        }
    }

    public void Insert(int value)
    {
        var insterted = new DoubleLinkedListItem(value);
        var item = this.start;
        while (item != null)
        {
            if (item.value >= value)
            {
                insterted.next = item;
                insterted.previous = item.previous;
                if (item.previous == null)
                {
                    start = insterted;
                }
                else
                {
                    item.previous.next = insterted;
                }
                item.previous = insterted;
                break;
            }
            item = item.next;
        }
        if (item == null)
        {
            if (start == null)
            {
                start = insterted;
            }
            else
            {
                end.next = insterted;
            }
            insterted.previous = end;
            end = insterted;
        }
    }

    public void Print()
    {
        var item = start;
        while (item != null)
        {
            Console.Write($"{item.value},");
            item = item.next;
        }
        Console.WriteLine("");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        int length = 5;
        var list = new DoubleLinkedList(length);
        list.Insert(0);
        list.Print();
        list = new DoubleLinkedList(length);
        list.Insert(length / 2);
        list.Print();
        list = new DoubleLinkedList(length);
        list.Insert(length);
        list.Print();
    }

}