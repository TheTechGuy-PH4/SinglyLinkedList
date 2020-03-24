using System;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList test = new SinglyLinkedList();

            Console.WriteLine("Test: ");
            test.AddFirst(10);
            test.AddFirst(20);
            test.AddFirst(30);
            test.AddFirst(40);
            Console.WriteLine("Singly Linked List After: AddFirst(10), AddFirst(20), AddFirst(30), AddFirst(40)");
            test.Print();
            Console.WriteLine();
            test.AddLast(50);
            test.AddLast(60);
            Console.WriteLine("Singly Linked List After: AddLast(50), AddLast(60)");
            test.Print();
            Console.WriteLine();
            test.Append(70);
            Console.WriteLine("Singly Linked List After: Append(70)");
            test.Print();
            Console.WriteLine();
            test.DeleteFirst();
            test.DeleteFirst();
            Console.WriteLine("Singly Linked List After: DeleteFirst() Twice");
            test.Print(); 
            Console.WriteLine();
            test.DeleteLast();
            Console.WriteLine("Singly Linked List After: DeleteLast()");
            test.Print();
            Console.WriteLine();
            test.Insert(4, 3);
            test.Insert(5, 1);
            Console.WriteLine("Singly Linked List After: Insert(4,3), Insert(5,1)");
            test.Print();
            Console.WriteLine();
            test.Delete(2);
            test.Delete(3);
            Console.WriteLine("Singly Linked List After: Delete(2), Delete(3)");
            test.Print();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Error Test: ");
            Console.WriteLine("No Values Have Been Inserted Into Linked List");
            Console.WriteLine();

            SinglyLinkedList error = new SinglyLinkedList();
            
            Console.WriteLine("Singly Linked List Error Message After: Print()");
            Console.WriteLine();

            error.Print();
            
            Console.WriteLine();
            Console.WriteLine("Singly Linked List Error Message After: DeleteFirst()");
            Console.WriteLine();

            error.DeleteFirst();
            
            Console.WriteLine();
            Console.WriteLine("Singly Linked List Error Message After: DeleteLast()");
            Console.WriteLine();

            error.DeleteLast();

            Console.WriteLine();
            Console.WriteLine("Singly Linked List After Insert(27, 0) With No Values In List");
            Console.WriteLine();
            Console.WriteLine("AddFirst() Will Be Called Instead: ");
            Console.WriteLine();

            error.Insert(27, 0);
            error.Print();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Singly Linked List Error Message After Delete() Called Twice");
            Console.WriteLine();
            
            error.Delete(0);
            error.Print();

            error.Delete(0);



        }

        class Node
        {
            public int data { get; set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                data = value;
            }
        }

        class SinglyLinkedList
        {
            Node head;

            public SinglyLinkedList()
            {
                head = null;
            }

            public void Print()
            {
                //1. Account for if head = null
                if (head == null)
                {
                    Console.WriteLine("Singly Linked List is Empty!!");
                    return;
                }
                //2. Create a pointer and assign the node 'head' as its value
                Node pointer = head;

                //3. Loop through list and print out the value of each node
                while (pointer != null)
                {
                    Console.Write(pointer.data + " ");
                    pointer = pointer.Next;
                }
            }

            public void AddFirst(int value)
            {
                //Create New Node to Insert
                Node newNode = new Node(value);
                //Assign the head node to newNode.Next
                //Places new node to the first node in the Linked List
                newNode.Next = head;
                //Assign newNode to head Node
                //Places the head Node as the first Node in the Linked List
                head = newNode;
            }

            public void AddLast(int value)
            {
                //1. Account for if head is null
                if (head == null)
                {
                    //2. If null, call AddFirst() method
                    AddFirst(value);
                }

                //3. Create newNode 
                Node newNode = new Node(value);

                //4. Create the node pointer and assign head to it
                Node pointer = head;

                //5. Loop through list until pointer is pointing towards last non-null node
                while (pointer.Next != null)
                {
                    //6. Move pointer to the right each time you go through loop
                    pointer = pointer.Next;
                }

                //7. Assign newNode to the .Next value of the last Non-Null node
                pointer.Next = newNode;
            }

            public void Append(int value)
            {
                //1. Append() = AddLast(), Call AddLast()
                AddLast(value);
            }

            public void DeleteFirst()
            {
                //Account for head being null/ List being empty
                if (head == null)
                {
                    //Error Message if head is null/ List is empty
                    Console.WriteLine("You cannot delete from an Empty list. Get it together my guy!!");
                    return;
                }
                else
                {
                    //Assign the next .Next node value to head
                    head = head.Next;
                }
            }

            public void DeleteLast()
            {
                //Account for head being null/ List being Empty
                if (head == null)
                {
                    //Throw Exception if head is null
                    Console.WriteLine("You can't delete from the end of an empty list!! Duh!!");
                    return;
                }
                //Account for if head.Next is null/ Only one item in list check
                else if (head.Next == null)
                {
                    //Assign null to head if there is only one node in the list
                    head = null;
                }
                else
                {
                    //Create pointer and assign the node head to it
                    Node pointer = head;

                    //Loop through list to find the last Non-Null Node
                    while (pointer.Next.Next != null)
                    {
                        //Move the pointer to the right once each time through loop
                        //At the end will have pointer, pointing towards the second to last node in list.
                        pointer = pointer.Next;
                    }

                    //Assign the second to last .Next node value to null
                    //Garbage Collector deletes Node that was unlinked
                    pointer.Next = null;
                }
                
            }

            public void Insert(int value, int index)
            {
                //Account for, if head = null and index = 0
                if (head==null && index == 0)
                {
                    //Call AddFirst Method if statement is true
                    AddFirst(value);
                    //Return: to exit method after this if statement is considered True
                    return;
                }

                //Create New Node
                Node newNode = new Node(value);

                //Create pointer and assign head to it
                Node pointer = head;

                //Iterate through loop to find the index - 1 insertion point
                //Stops at the node before the desired index insertion point
                for (int pos = 0; pos < index - 1; pos++)
                {
                    //Make sure the list isnt empty
                    if (pointer == null)
                    {
                        //If the list is empty, Call AddFirst Method
                        AddFirst(value);
                        return;
                    }

                    //Move the pointer to the right each time we go through the loop
                    pointer = pointer.Next;
                }

                //Insert node by assigning the pointer.Next value to the newNode.Next
                //Will point the pointer to the node that comes after the desired index location
                newNode.Next = pointer.Next;
                //Assign the newNode to the pointer.Next
                //Will move the pointer from original node in list, to the New Node that has been inserted
                //Ultimately completeing the insertion process
                pointer.Next = newNode;
            }

            public void Delete(int index)
            {
                //Account for if the index is less than 0
                if (index < 0)
                {
                    //Return statement to leave method
                    return;
                }
                //Account for if index = 0
                if (index == 0)
                {
                    //If index = 0, then call the DeleteFirst Method
                    DeleteFirst();
                    //Return statement to leave method
                    return;
                }
                //Account for if head is null 
                if (head == null)
                {
                    //If head is null, Print a message
                    Console.WriteLine("You cannot delete from an empty list");
                    //Return statement to leave method
                    return;
                }
                
                //Create Pointer
                Node pointer = head;

                //Iterate through loop to find the index - 1 position
                for (int pos = 0; pos < index - 1; pos++)
                {
                    //Move pointer to the right every iteration
                    pointer = pointer.Next;
                }

                //If Pointer is not empty, and the next Node is not empty
                //Assign the .Next value to the node after the node you want to delete from the list
                if (pointer != null && pointer.Next != null)
                    pointer.Next = pointer.Next.Next;
                else
                    Console.WriteLine("You cant do that bro!!");
            }
        }
    }
}
