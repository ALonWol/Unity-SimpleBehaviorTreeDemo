using UnityEngine;

namespace BehaviorTree {
    public class BTAgent : MonoBehaviour
    {
        protected INode brain;

        // Start is called before the first frame update
        void Start()
        {
            Setup();
        }

        // Update is called once per frame
        void Update()
        {
            brain?.Excute();
        }

        virtual protected void Setup() {}

        virtual protected void EarlyUpdate() {}

        virtual protected void Terminate() {}
    }
}