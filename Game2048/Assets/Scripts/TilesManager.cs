using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// a struct store grid index pair
struct GridIndexPair{
	public int Row; 
	public int Column;
	public GridIndexPair(int r, int c){
		Row = r;
		Column = c;
	}
}

// a enum store the game state
enum GameState{
	WaitForInput,
	HandleInput,
	GameOver,
	GameWin
}

public class TilesManager : MonoBehaviour {

	public Vector2 firstPosition;
	public float tileWidth;
	public float borderWidth;
	public int maxRows;
	public int maxColumns;
	public GameObject[] tiles;
	public Text gameStateText;
	public GameObject tileForCheck;

	private GameState gameState;

	private GameObject[,] gridState;

	// Use this for initialization
	void Start () {
		//TestBuildFullTitles ();
		gridState = new GameObject[maxRows, maxColumns];



		GameInit ();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameState == GameState.WaitForInput){
//			if(Input.GetKeyDown(KeyCode.Space)){
//				gameState = GameState.HandleInput;
//				RandowmBuildTile();
//			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				gameState = GameState.HandleInput;
				MoveLeft();
			}
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				gameState = GameState.HandleInput;
				MoveRight();
			}
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				gameState = GameState.HandleInput;
				MoveUp();
			}
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				gameState = GameState.HandleInput;
				MoveDown();
			}
		}

		if (gameState == GameState.HandleInput) {
			if(CheckGameOver())
				gameState = GameState.GameOver;
			else{
				gameState = GameState.WaitForInput;
				// add a new tile
				RandowmBuildTile();
			}
		}

		UpdateText ();

	}

	// update game state text
	void UpdateText(){
		if (gameState == GameState.GameOver) {
			gameStateText.text = "GameOver ";
		}
		if (gameState == GameState.GameWin) {
			gameStateText.text = "GameWin";
		}
	}

	// game initialize
	void GameInit(){
		gameState = GameState.WaitForInput;
		gameStateText.text = "2048";
		RandowmBuildTile ();
		RandowmBuildTile ();
	}

	// check game over
	bool CheckGameOver(){
		bool isGameOver = true;
		for (int i=0; i< maxRows; i++) {
			for(int j=0; j<maxColumns; j++){
				GameObject here = gridState[i, j];
				// reset current turn flag
				if(here)
					here.GetComponent<Tiles>().mergeInThisTurn = false;

				// check right and bottom tiles
				GameObject right;
				if(j == maxColumns-1)
					right = tileForCheck;
				else 
					right = gridState[i, j+1];

				GameObject bottom;
				if(i == maxRows -1)
					bottom = tileForCheck;
				else
					bottom = gridState[i+1, j];

				if(!here || !right || !bottom )
					isGameOver =  false;
				else if(here.GetComponent<Tiles>().value == right.GetComponent<Tiles>().value ||
				        here.GetComponent<Tiles>().value == bottom.GetComponent<Tiles>().value){
					isGameOver =  false;
				}

			}		
		}
		return isGameOver;
	}
	// check game win
	bool CheckGameWin(){
		return false;
	}

	// Move Left
	void MoveLeft(){
		for (int i=0; i<maxRows; i++) {
			for(int j=0; j<maxColumns; j++){
				// do noting with empty tile and the leftest tile
				if(!gridState[i,j] || j == 0)
					continue;
				for(int col = j-1; col >= 0; col--){
					// when there is an other tile sit left;
					if(gridState[i, col]){
						// when with the same value tile
						if(gridState[i, col].GetComponent<Tiles>().value == gridState[i, j].GetComponent<Tiles>().value
						   && !gridState[i, col].GetComponent<Tiles>().mergeInThisTurn
						   && !gridState[i, j].GetComponent<Tiles>().mergeInThisTurn){
							MergeTwoSameTile(gridState[i, col], 
							                 gridState[i, j], 
							                 new GridIndexPair(i, j),
							                 new GridIndexPair(i, col));
						}else{
							// move left;
							if(col != j-1){
								col ++;
								MoveToNewPlace(gridState[i,j], new GridIndexPair(i, j), new GridIndexPair(i, col));
							}
						}
					}
					// when not;
					else{
						// keep searching
						if(col != 0 )
							continue;
						else{
							MoveToNewPlace(gridState[i,j], new GridIndexPair(i, j), new GridIndexPair(i, col));
						}
					}

					// now we can stop
					break;
				}
			}
		}
	}

	// Move Right
	void MoveRight(){
		for (int i=0; i<maxRows; i++) {
			// start seaching from right
			for(int j=maxColumns-1; j>=0; j--){
				// do noting with empty tile and the rightest tile
				if(!gridState[i,j] || j == maxColumns-1)
					continue;
				for(int col = j+1; col < maxColumns; col++){
					// when there is an other tile sit left;
					if(gridState[i, col]){
						// when with the same value tile
						if(gridState[i, col].GetComponent<Tiles>().value == gridState[i, j].GetComponent<Tiles>().value
						   && !gridState[i, col].GetComponent<Tiles>().mergeInThisTurn
						   && !gridState[i, j].GetComponent<Tiles>().mergeInThisTurn){
							MergeTwoSameTile(gridState[i, col], 
							                 gridState[i, j], 
							                 new GridIndexPair(i, j),
							                 new GridIndexPair(i, col));
						}else{
							// move right;
							if(col != j+1){
								col --;
								MoveToNewPlace(gridState[i,j], new GridIndexPair(i, j), new GridIndexPair(i, col));
							}
						}
					}
					// when not;
					else{
						// keep searching
						if(col != maxColumns -1 )
							continue;
						else{
							MoveToNewPlace(gridState[i,j], new GridIndexPair(i, j), new GridIndexPair(i, col));
						}
					}
					
					// now we can stop
					break;
				}
			}
		}
	}

	// Move Up
	void MoveUp(){
		for (int i=0; i<maxRows; i++) {
			for(int j=0; j<maxColumns; j++){
				// do noting with empty tile and the toppest tile
				if(!gridState[i,j] || i == 0)
					continue;
				for(int row = i-1; row >= 0; row--){
					// when there is an other tile sit left;
					if(gridState[row, j]){
						// when with the same value tile
						if(gridState[row, j].GetComponent<Tiles>().value == gridState[i, j].GetComponent<Tiles>().value
						   &&!gridState[row, j].GetComponent<Tiles>().mergeInThisTurn
						   &&!gridState[i,j].GetComponent<Tiles>().mergeInThisTurn){
							MergeTwoSameTile(gridState[row, j], 
							                 gridState[i, j], 
							                 new GridIndexPair(i, j),
							                 new GridIndexPair(row, j));
						}else{
							// move up;
							if(row != i-1){
								row ++;
								MoveToNewPlace(gridState[i,j], new GridIndexPair(i, j), new GridIndexPair(row, j));
							}
						}
					}
					// when not;
					else{
						// keep searching
						if(row != 0 )
							continue;
						else{
							MoveToNewPlace(gridState[i,j], new GridIndexPair(i, j), new GridIndexPair(row, j));
						}
					}
					
					// now we can stop
					break;
				}
			}
		}
	}

	// Move Down
	void MoveDown(){
		// start search from bottom side
		for (int i=maxRows-1; i>=0; i--) {
			for(int j=0; j<maxColumns; j++){
				// do noting with empty tile and the bottom tile
				if(!gridState[i,j] || i == maxRows-1)
					continue;
				for(int row = i+1; row < maxRows; row++){
					// when there is an other tile sit left;
					if(gridState[row, j]){
						// when with the same value tile
						if(gridState[row, j].GetComponent<Tiles>().value == gridState[i, j].GetComponent<Tiles>().value
						   && !gridState[row,j].GetComponent<Tiles>().mergeInThisTurn
						   && !gridState[i,j].GetComponent<Tiles>().mergeInThisTurn){
							MergeTwoSameTile(gridState[row, j], 
							                 gridState[i, j], 
							                 new GridIndexPair(i, j),
							                 new GridIndexPair(row, j));
						}else{
							// move down;
							if(row != i+1){
								row --;
								MoveToNewPlace(gridState[i,j], new GridIndexPair(i, j), new GridIndexPair(row, j));
							}
						}
					}
					// when not;
					else{
						// keep searching
						if(row != maxRows -1 )
							continue;
						else{
							MoveToNewPlace(gridState[i,j], new GridIndexPair(i, j), new GridIndexPair(row, j));
						}
					}
					
					// now we can stop
					break;
				}
			}
		}
	}

	// merge same tile
	void MergeTwoSameTile(GameObject tileA, GameObject tileB,GridIndexPair oldIndexPair ,GridIndexPair targetIndexPair){
		GameObject go = Instantiate (tiles [tileA.GetComponent<Tiles> ().nextIndex],
		                            GetWorldPositionByGridIndex (targetIndexPair),
		                            Quaternion.identity) as GameObject;
		Destroy (tileA.gameObject);
		Destroy (tileB.gameObject);
		gridState [targetIndexPair.Row, targetIndexPair.Column] = go;
		gridState [oldIndexPair.Row, oldIndexPair.Column] = null;

		// set current turn
		go.GetComponent<Tiles> ().mergeInThisTurn = true;

		// check if merge a tile with value 2048
		if(go.GetComponent<Tiles>().value == 2048)
			gameState = GameState.GameWin;
	}

	// move the tile to a new place
	void MoveToNewPlace(GameObject tileA, GridIndexPair oldIndex, GridIndexPair newIndex){
		tileA.transform.position = GetWorldPositionByGridIndex (newIndex);
		gridState [newIndex.Row, newIndex.Column] = tileA;
		gridState [oldIndex.Row, oldIndex.Column] = null;
	}

	// random build a tile
	void RandowmBuildTile(){
		List<GridIndexPair> emptyGridsIndexPairs = new List<GridIndexPair>();
		for(int i=0; i<maxRows; i++){
			for(int j=0; j<maxColumns; j++){
				if(!gridState[i,j]){
					GridIndexPair pair;
					pair.Row = i;
					pair.Column = j;
					emptyGridsIndexPairs.Add(pair);
				}
			}
		}
		if(emptyGridsIndexPairs.Count == 0)
			return;
		else{
			int r = Random.Range (0, emptyGridsIndexPairs.Count);
			GridIndexPair indexPair = emptyGridsIndexPairs[r];
			if(Random.Range(0.0f, 9.9f) > 8.0f)
				gridState[indexPair.Row,indexPair.Column] = Instantiate(tiles[1], GetWorldPositionByGridIndex(indexPair), Quaternion.identity) as GameObject;
			else
				gridState[indexPair.Row,indexPair.Column] = Instantiate(tiles[0], GetWorldPositionByGridIndex(indexPair), Quaternion.identity) as GameObject;
		}
	}


	// return position by grid index
	Vector2 GetWorldPositionByGridIndex(GridIndexPair indexPair){
		Vector2 worldPosition = Vector2.zero;
		worldPosition.x = firstPosition.x + indexPair.Column * (tileWidth + borderWidth);
		worldPosition.y = firstPosition.y - indexPair.Row * (tileWidth + borderWidth);
		return worldPosition;
	}

	// return grid index by position
	GridIndexPair GetGridIndexByWorldPosition(Vector2 worldPosition){
		int c = (int)((worldPosition.x - firstPosition.x) / (tileWidth + borderWidth));
		int r = (int)((firstPosition.y - worldPosition.y) / (tileWidth + borderWidth));
		GridIndexPair indexPair;
		indexPair.Row = r;
		indexPair.Column = c;
		return indexPair;
	}

	// test the relationship between grid index and position
	void TestBuildFullTitles(){
		List<GameObject> objects = new List<GameObject>();
		GridIndexPair indexPair;
		for (int r=0; r < maxRows; r++) {
			for(int c=0; c < maxColumns; c++){
				indexPair.Row = r;
				indexPair.Column = c;
				GameObject go =  Instantiate(tileForCheck, 
				                             GetWorldPositionByGridIndex(indexPair), 
				                             Quaternion.identity)
											as GameObject;
				objects.Add(go);

			}		
		}
		foreach (GameObject g in objects) {
			print (GetGridIndexByWorldPosition(g.transform.position).Row +
			       "," +
			       GetGridIndexByWorldPosition(g.transform.position).Column);		
		}
	}
}
