using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankOneWeekPreparationKit
{
    public class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    public class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    public static class SinglyList
    {
        public static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }

        // Complete the mergeLists function below.

        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        public static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedList linkedList = new SinglyLinkedList();


            while ( head1 !=null || head2 != null)
            {
                if ( head1 != null && ( head2 == null || head1.data< head2.data))
                {
                    linkedList.InsertNode(head1.data);
                    head1 = head1.next;
                }
                else
                {
                    linkedList.InsertNode(head2.data);
                    head2 = head2.next;
                }
            }

            return linkedList.head;

        }
    }
}
