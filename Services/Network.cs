namespace GraphsBenner.Service;

public class Network
{
    private readonly int nodeAmount;

    // Matriz como Linked List pra adicionar elementos usando AddLast ao invés de 
    // percorrer até o final
    private LinkedList<int>[] adjacencyMatrix;

    public Network(int nodeAmount)
    {
        if(!isValidNodeAmount(nodeAmount)) {
            throw new Exception("Node amount must be a positive integer");
        }

        this.nodeAmount = nodeAmount;
        adjacencyMatrix = new LinkedList<int>[nodeAmount];

        // Decidi considerar um Node 0 pra facilitar a implementação
        for (int i = 0; i < nodeAmount; i++)
        {
            adjacencyMatrix[i] = new LinkedList<int>();
        }
    }

    public void Connect(int nodeA, int nodeB)
    {
        if(!isValidNode(nodeA) || !isValidNode(nodeB)) {
            throw new Exception("Invalid Node Numbers");
        }

        adjacencyMatrix[nodeA].AddLast(nodeB);
        adjacencyMatrix[nodeB].AddLast(nodeA);
    }
    
    public bool Query(int nodeA, int nodeB)
    {
        if(!isValidNode(nodeA) || !isValidNode(nodeB)) {
            throw new Exception("Invalid Node Numbers");
        }

        bool[] visitedNodes = new bool[nodeAmount];
        return areConnected(nodeA, nodeB, visitedNodes);
    }

    private bool areConnected(int nodeA, int nodeB, bool[] visitedNodes)
    {
        if (nodeA == nodeB)
        {
            return true;
        }

        visitedNodes[nodeA] = true;

        foreach(int currentNode in adjacencyMatrix[nodeA]) {
            if(!visitedNodes[currentNode]) {
                if(areConnected(currentNode, nodeB, visitedNodes)) {
                    return true;
                }
            }
        }

        return false;
    }

    private bool isValidNode(int node) {
        return 0 <= node && node < nodeAmount;
    }

    private bool isValidNodeAmount(int nodeAmount) {
        return nodeAmount >= 1;
    }
}

// [[2, 3], [4, 5], [1, 2]]