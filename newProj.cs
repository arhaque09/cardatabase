using System; 

class Node { 
    public string name; 
    public int year; 
    public string color; 
    public string make; 
    public string accidents; 
    public Node next = null; 
    public Node prev = null; 
    public int index; 
}

class LinkedList { 
    int numNodes = 0; 
    Node head = null; 
    Node tail = null; 

    public void addNode(string Name, string Make, int Year, string Color, string Accidents) { 
        Node newNode = new Node(); 
        newNode.name = Name; 
        newNode.year = Year;
        newNode.color = Color; 
        newNode.make = Make; 
        newNode.accidents = Accidents; 

        if (numNodes == 0) { 
            head = newNode; 
            tail = newNode;
            newNode.index = 0; 
        } else { 
            tail.next = newNode; 
            newNode.prev = tail; 
            tail = newNode; 
            newNode.index = numNodes + 1; 
        }
        numNodes++;
    }

    public void findNode(string Name, string Make) { 
        Node currentNode = head; 
        bool found = false; 

        while (currentNode != null && found == false) { 
            if (currentNode.name == Name && currentNode.make == Make) { 
                Console.WriteLine("Name: " + currentNode.name); 
                Console.WriteLine("Make: " + currentNode.make); 
                Console.WriteLine("Year: " + currentNode.year); 
                Console.WriteLine("Color: " + currentNode.color); 
                Console.WriteLine("Accidents: " + currentNode.accidents); 
                found = true; 
            } else { 
                currentNode = currentNode.next; 
            }
        }

        if (found == false) { 
            Console.WriteLine("Not Found"); 
        }
    }

    public void deleteNode(string Name, string Make) { 
        Node currentNode = head; 
        bool found = false; 

        while (currentNode != null && found == false) { 
            if (currentNode.name == Name && currentNode.make == Make) { 
                found = true; 
            } else { 
                currentNode = currentNode.next; 
            }
        }

        if (found == false) { 
            Console.WriteLine("Not Found"); 
            return; 
        }

        if (currentNode.prev != null) {
            currentNode.prev.next = currentNode.next; 
        } else {
            head = currentNode.next;
        }

        if (currentNode.next != null) {
            currentNode.next.prev = currentNode.prev; 
        } else {
            tail = currentNode.prev;
        }

        numNodes--;
    }
}

class Program { 
    
    static void Main(string[] args) {
        Console.WriteLine("hello world"); 
        LinkedList test = new LinkedList(); 

        test.addNode("Toyota", "Camry", 2017, "Blue", "Yes"); 
        test.findNode("Toyota", "Camry"); 
    }
}