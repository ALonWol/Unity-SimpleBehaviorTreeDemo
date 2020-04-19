using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {
    public class RandomSelector : Composite, INode {
        private bool randomed;

        private int successCount;

        public RandomSelector() {
            randomed = false;
            successCount = 0;
        }

        override public Status Excute() {
            var unusedIndex = new List<int>();
            for (int i = 0; i < Nodes.Count; i++) {
                unusedIndex.Add(i);
            }

            if (!randomed) {
                nodeIndex = unusedIndex[Random.Range(0, unusedIndex.Count)];
            }

            do {
                var status = Nodes[nodeIndex].Excute();

                switch (status) {
                    case Status.Failure:
                        unusedIndex.Remove(nodeIndex);
                        nodeIndex = unusedIndex[Random.Range(0, unusedIndex.Count)];
                        continue;
                    case Status.Success:
                        randomed = false;
                        successCount++;
                        return Status.Success;
                    case Status.Running:
                        randomed = true;
                        return Status.Running;
                }
            } while (randomed && unusedIndex.Count > 0);

            randomed = false;

            return Status.Failure;
        }
    }
}