using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] float _timeForNewFinderPath;
    [SerializeField] LayerMask _solidLayer;
    List<Vector2> _pathToTarget;

    List<Node> _freeNodes = new List<Node>();
    List<Node> _checkedNodes = new List<Node>();
    List<Node> _waitingNodes = new List<Node>();
    Transform _target;

    float _timer;

    private void Start()
    {
        _target = FindObjectOfType<Pig>().transform;
        _pathToTarget = GetPath(_target.position);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _timeForNewFinderPath)
        {
            _pathToTarget = GetPath(_target.position);
            _timer = 0;
        }
    }

    public List<Vector2> PathToTarget => _pathToTarget;

    public List<Node> FreeNodes => _freeNodes;
    public List<Vector2> GetPath(Vector2 target)
    {
        _pathToTarget = new List<Vector2>();
        _checkedNodes = new List<Node>();
        _waitingNodes = new List<Node>();

        var StartPosition = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        var TargetPosition = new Vector2(Mathf.Round(target.x), Mathf.Round(target.y));
        
        if(StartPosition == TargetPosition) return _pathToTarget;

        var startNode = new Node(0, StartPosition, TargetPosition, null);
        _checkedNodes.Add(startNode);
        _waitingNodes.AddRange(GetNeighbourNodes(startNode));
        while(_waitingNodes.Count > 0)
        {
            var nodeToCheck = _waitingNodes.Where(x => x.F == _waitingNodes.Min(y => y.F)).FirstOrDefault();

            if (nodeToCheck.Position == TargetPosition)
            {
                return CalculatePathFromNode(nodeToCheck);
            }

            var walkable = !Physics2D.OverlapCircle(nodeToCheck.Position, 0.1f, _solidLayer);
            if(!walkable)
            {
                _waitingNodes.Remove(nodeToCheck);
                _checkedNodes.Add(nodeToCheck);
            }
            else if(walkable)
            {
                _waitingNodes.Remove(nodeToCheck);
                if(!_checkedNodes.Where(x => x.Position == nodeToCheck.Position).Any()) {
                    _checkedNodes.Add(nodeToCheck);
                    _waitingNodes.AddRange(GetNeighbourNodes(nodeToCheck));
                } 
            }
        }
        _freeNodes = _checkedNodes;

        return _pathToTarget;
    }

    List<Vector2> CalculatePathFromNode(Node node)
    {
        var path = new List<Vector2>();
        var currentNode = node;

        while(currentNode.PreviousNode != null)
        {
            path.Add(new Vector2(currentNode.Position.x, currentNode.Position.y));
            currentNode = currentNode.PreviousNode;
        }

        return path;
    }

    List<Node> GetNeighbourNodes (Node node)
    {
        var Neighbours = new List<Node>();

        Neighbours.Add(new Node(node.G + 1, new Vector2(
            node.Position.x-1, node.Position.y), 
            node.TargetPosition, 
            node));
        Neighbours.Add(new Node(node.G + 1, new Vector2(
            node.Position.x+1, node.Position.y),
            node.TargetPosition,
            node));
        Neighbours.Add(new Node(node.G + 1, new Vector2(
            node.Position.x, node.Position.y-1),
            node.TargetPosition,
            node));
        Neighbours.Add(new Node(node.G + 1, new Vector2(
            node.Position.x, node.Position.y+1),
            node.TargetPosition,
            node));
        return Neighbours;
    }
    void OnDrawGizmos()
    {
        foreach (var item in _checkedNodes)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(new Vector2(item.Position.x, item.Position.y), 0.1f);
        }
        if (_pathToTarget != null)
            foreach (var item in _pathToTarget)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(new Vector2(item.x, item.y), 0.2f);
            }
    }

}
