using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using static finished3.ArrowTranslator;

namespace finished3
{
    public class MouseController : MonoBehaviour
    {
        private static MouseController _instance;
        public static MouseController Instance { get { return _instance; } }
        public OverlayTile checkTile;
        public OverlayTile tile;
        public Vector2 currentTile;
        public Vector2 startingTile;
        public GameObject cursor;
        public float speed;
        public GameObject characterPrefab;
        public CharacterInfo character;
        public FacingDir dirToFace;
        private PathFinder pathFinder;
        private RangeFinder rangeFinder;
        private ArrowTranslator arrowTranslator;
        private List<OverlayTile> path;
        private List<OverlayTile> rangeFinderTiles;
        private bool isMoving;
        public CharacterController currentCharacter;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else
            {
                _instance = this;
            }
        }
        private void Start()
        {
            pathFinder = new PathFinder();
            rangeFinder = new RangeFinder();
            arrowTranslator = new ArrowTranslator();

            path = new List<OverlayTile>();
            isMoving = false;
            rangeFinderTiles = new List<OverlayTile>();
        }

        void LateUpdate()
        {
            RaycastHit2D? hit = GetFocusedOnTile();
            
            if (hit.HasValue)
            {
                OverlayTile tile = hit.Value.collider.gameObject.GetComponent<OverlayTile>();
                cursor.transform.position = tile.transform.position;
                cursor.gameObject.GetComponent<SpriteRenderer>().sortingOrder = tile.transform.GetComponent<SpriteRenderer>().sortingOrder;

                if (rangeFinderTiles.Contains(tile) && !isMoving)
                {
                    path = pathFinder.FindPath(character.standingOnTile, tile, rangeFinderTiles);
                    
                    foreach (var item in rangeFinderTiles)
                    {
                        MapManager.Instance.map[item.grid2DLocation].SetSprite(ArrowDirection.None);
                    }

                    for (int i = 0; i < path.Count; i++)
                    {
                        var previousTile = i > 0 ? path[i - 1] : character.standingOnTile;
                        var futureTile = i < path.Count - 1 ? path[i + 1] : null;
                        var arrow = arrowTranslator.TranslateDirection(previousTile, path[i], futureTile);
                        path[i].SetSprite(arrow);
                    }
                }
                UpdateCurrentTile(tile.grid2DLocation);
                
                if (Input.GetMouseButtonDown(0))
                {
                    tile.ShowTile();
                    if (character == null)
                    {
                        character = Instantiate(characterPrefab).GetComponent<CharacterInfo>();
                        PositionCharacterOnLine(tile);
                        GetInRangeTiles();
                        currentTile = tile.grid2DLocation;
                        dirToFace = directionToFace(tile.grid2DLocation, currentTile);

                        currentCharacter = character.GetComponentInChildren<CharacterController>();
                        currentCharacter.StopWalking(dirToFace);
                    }
                    else
                    {
                        isMoving = true;
                        tile.gameObject.GetComponent<OverlayTile>().HideTile();
                        dirToFace = directionToFace(tile.grid2DLocation, currentTile);
                        currentCharacter.StartWalking(dirToFace);
                    }
                }
            }

            if (path.Count > 0 && isMoving)
            {
                MoveAlongPath();
            }
        }
        FacingDir directionToFace(Vector2 currentTile, Vector2 startingTile)
        {
            FacingDir dir;
            if (currentTile.x > startingTile.x && currentTile.y > startingTile.y)
            {
                dir = FacingDir.BackLeft;
            }
            else if (currentTile.x == startingTile.x && currentTile.y > startingTile.y)
            {
                dir = FacingDir.BackLeft;
            }
            else if (currentTile.x == startingTile.x && currentTile.y < startingTile.y)
            {
                dir = FacingDir.FrontRight;
            }
            else if (currentTile.x > startingTile.x && currentTile.y < startingTile.y)
            {
                dir = FacingDir.BackRight;
            }
            else if (currentTile.x < startingTile.x && currentTile.y > startingTile.y)
            {
                dir = FacingDir.FrontLeft;
            }
            else if (currentTile.x > startingTile.x && currentTile.y == startingTile.y)
            {
                dir = FacingDir.BackRight;
            }
            else if (currentTile.x < startingTile.x && currentTile.y == startingTile.y)
            {
                dir = FacingDir.FrontLeft;
            }
            else
            {
                dir = FacingDir.FrontRight;
            }
            return dir;
        }
        private void MoveAlongPath()
        {
            var step = speed * Time.deltaTime;
            currentCharacter.StartWalking(directionToFace(currentTile, startingTile));
            
            float zIndex = path[0].transform.position.z;
            character.transform.position = Vector2.MoveTowards(character.transform.position, path[0].transform.position, step);
            character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, zIndex);

            if (Vector2.Distance(character.transform.position, path[0].transform.position) < 0.00001f)
            {
                PositionCharacterOnLine(path[0]);
                path.RemoveAt(0);
            }

            if (path.Count == 0)
            {
                GetInRangeTiles();
                isMoving = false;
                dirToFace = directionToFace(currentTile, startingTile);

                currentCharacter.StopWalking(dirToFace);
                startingTile = currentTile;
            }
        }

        private void PositionCharacterOnLine(OverlayTile tile)
        {
            character.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z);
            //character.GetComponentInChildren<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
            character.standingOnTile = tile;
            
        }
        void UpdateCurrentTile(Vector2 mousePos2D)
        {
            currentTile = mousePos2D;
        }

        private static RaycastHit2D? GetFocusedOnTile()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

            if (hits.Length > 0)
            {
                return hits.OrderByDescending(i => i.collider.transform.position.z).First();
            }

            return null;
        }

        private void GetInRangeTiles()
        {
            rangeFinderTiles = rangeFinder.GetTilesInRange(new Vector2Int(character.standingOnTile.gridLocation.x, character.standingOnTile.gridLocation.y), 3);
            foreach (var item in rangeFinderTiles)
            {
                item.ShowTile();
            }
        }
        public OverlayTile GetTileAtCoordinates(int _x, int _y)
        {
            return MapManager.Instance.map[new Vector2Int(_x, _y)];
        }
        public void SpawnCharacter(GameObject characterPrefab){
            character = Instantiate(characterPrefab).GetComponent<CharacterInfo>();        }
    }
}

[CustomEditor(typeof(finished3.MouseController))]
public class MouseControllerEditor : Editor
{
    int _x;
    int _y;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        finished3.MouseController myScript = (finished3.MouseController)target;
        _x = EditorGUILayout.IntField("X", _x);
        _y = EditorGUILayout.IntField("Y", _y);
        if(GUILayout.Button("Get Tile At Coordinates")){
            myScript.checkTile = myScript.GetTileAtCoordinates(_x,_y);
        }
    }
}