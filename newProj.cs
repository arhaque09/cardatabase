using System; 

class Node { 
    public string name; 
    public int year; 
    public string color; 
    public string make; 
    public string accidents; 
    public Node next; 
    public Node prev;     
    public int index; 
}

class LinkedList { 
    int numNodes = 0; 
    Node head; 
    Node tail; 

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
    
        LinkedList test = new LinkedList(); 
        string option = ""; 
        test.addNode("Toyota", "Camry", 2017, "Blue", "Yes"); 
        test.findNode("Toyota", "Camry"); 
        while (option != "4") { 
            Console.WriteLine("Pick from the following options: "); 
            Console.WriteLine("1. Add a Car");
            Console.WriteLine("2. Find a Car");
            Console.WriteLine("3. Delete a Car");
            Console.WriteLine("4. Quit App");
            option = Console.ReadLine(); 
            if (option == "1") { 
                Console.WriteLine("Give the name of the company: "); 
                string Name = Console.ReadLine(); 
                Console.WriteLine("Give the name of the make: "); 
                string Make = Console.ReadLine(); 
                Console.WriteLine("Give the year: "); 
                int Year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Give the color: "); 
                string Color = Console.ReadLine(); 
                Console.WriteLine("Was there any accidents with this vehicle (yes or no): "); 
                string Accidents = Console.ReadLine(); 
                test.addNode(Name, Make, Year, Color, Accidents); 

            }
            if (option == "2") { 
                Console.WriteLine("Give the name of the company: "); 
                string Name = Console.ReadLine(); 
                Console.WriteLine("Give the make of the car: "); 
                string Make = Console.ReadLine(); 
                test.findNode(Name, Make); 
            }
            if (option == "3") {
                Console.WriteLine("Give the name of the company: "); 
                string Name = Console.ReadLine(); 
                Console.WriteLine("Give the make of the car: ");
                string Make = Console.ReadLine(); 
                test.deleteNode(Name, Make);  

            }

        }
        


        
    }
}
