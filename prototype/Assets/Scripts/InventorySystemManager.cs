using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemManager : MonoBehaviour {
    // Start is called before the first frame update
    public static InventorySystemManager inst;
    public int size;
    public FixedQueue<string> bagQueue;
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
