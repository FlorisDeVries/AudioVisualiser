using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWriter3D : MonoBehaviour {

	public bool scrolling = true;
	public char[] letters;
	public GameObject[] letters3D;
	public string[] zinnen;

	public float width, height;
	private Dictionary<char, GameObject> lettersDic = new Dictionary<char, GameObject>();
	Quaternion turnAround = new Quaternion(0,180,0, 0);

	// Use this for initialization
	void Start () {

		for (int i = 0; i < letters.Length; i++){
			lettersDic.Add(letters[i], letters3D[i]);
		}

		for (int i = 0; i < zinnen.Length; i++){
			DrawSentence(zinnen[i], i);
		}
	}

	void DrawSentence(string zin, int y){
		string[] words = zin.Split();
		int length = 0;
		int letterCount = 0;
		foreach (string word in words){
			letterCount += word.Length;
		}

		for (int i = 0; i < words.Length; i++){
			DrawWord(words[i],i , y, letterCount, length);
			length += words[i].Length;
		}
	}

	void DrawWord(string word, int x, int y, int letterCount, int charLength){
		for (int i = 0; i < word.Length; i++){
			DrawLetter(word[i], new Vector2(charLength + i + x, y), letterCount);
		}
	}

	void DrawLetter(char letter, Vector2 pos, int letterCount){
		GameObject letter3D;
		bool upper = char.IsUpper(letter);
		if(upper)
			letter = char.ToLower(letter);

		if(lettersDic.TryGetValue(letter, out letter3D)){
			GameObject instance = Instantiate(letter3D, new Vector3(transform.position.x + (pos.x * width - letter3D.GetComponent<Renderer>().bounds.size.x / 2) - ((width * letterCount) / 2), transform.position.y + -pos.y * height - 4 * height, transform.position.z), turnAround);
			instance.GetComponent<Letter>().band = Random.Range(0,8);
			if(!scrolling)
				instance.GetComponent<Scrollertje>().enabled = false;
			if(upper)
				instance.GetComponent<Letter>().startScale = 200;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
