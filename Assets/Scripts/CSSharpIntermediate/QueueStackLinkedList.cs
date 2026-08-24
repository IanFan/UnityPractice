using System.Collections.Generic;
using UnityEngine;


public class QueueStackLinkedList : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("Jack");
        queue.Enqueue("May");
        Debug.Log(string.Join(",", queue));
        Debug.Log(queue.Count);
        Debug.Log(queue.Peek());
        
        if (queue.TryDequeue(out string character))
        {
            Debug.Log(character);
        }
        
        Stack<string> stack = new Stack<string>();
        stack.Push("Jack");
        stack.Push("May");
        Debug.Log(string.Join(",", stack));
        Debug.Log(stack.Count);
        Debug.Log(stack.Peek());
        
        if (stack.TryPop(out character))
        {
            Debug.Log(character);
        }
        
        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.AddFirst("Jack");
        linkedList.AddLast("May");
        Debug.Log(string.Join(",", linkedList));
        Debug.Log(linkedList.Count);
        
        LinkedListNode<string> node = linkedList.First;
        Debug.Log(node.Value);
        Debug.Log(node.Next.Value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
