using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemManager : MonoBehaviour {
    // Start is called before the first frame update
    public static InventorySystemManager inst;
    public int size;
    public FixedQueue<string> bagQueue;
    public GameObject aniamtionBox;
    void Start() {
        bagQueue = new FixedQueue<string>(size);

    }

    // Update is called once per frame
    void Update() {

    }
    void Awake() {
        inst = this;
    }
    public void addIngredent(string name) {

        inst.bagQueue.Enqueue(name);
        player2bag.inst.MoveToBag(name);

    }

    public bool didGetAllIngredentInBag() {
        List<string> list = new List<string>(bagQueue);
        list = list.ConvertAll(d => d.ToUpper());
        foreach (KeyValuePair<string, Ingredient> pair in GameTracker.ingredientsList) {
            if (!list.Contains(pair.Key.ToString().ToUpper())) {

                return false;
            }
            list.Remove(pair.Key.ToString());
        }

        return true;

    }
    public void emptyBag() {
        inst.bagQueue = new FixedQueue<string>(size);
        aniamtionBox.SetActive(false);
    }

    public int qSize() {
        return inst.bagQueue.Count;
    }

    public void loseRecentIngredient(){
        List<string> list = new List<string>(bagQueue);
        list.RemoveAt(list.Count - 1);
        emptyBag();
        foreach (string name in list) {
            inst.bagQueue.Enqueue(name);
        }
    }
    public class FixedQueue<T> : Queue<T> {
        public int QSize;

        public FixedQueue(int size) {
            QSize = size;
        }

        public new void Enqueue(T val) {
            base.Enqueue(val);
            if (this.Count > QSize) {
                this.Dequeue();
            }
        }
    }
}
