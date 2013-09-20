using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Observer
{
    #region The Subject 

    // the subject abstract class
    public abstract class Arrow
    {
        private List<Maze> _observers = new List<Maze>();

        public void Attach(Maze m) { _observers.Add(m); }

        public void Detach(Maze m) { _observers.Remove(m); }

        public void Notify()
        {
            foreach (Maze m in _observers)
                m.Update();            
        }
    }

    public struct SubjectState
    {
        public int X;
        public int Y;
        public string Direction;
    }

    // concrete subject class
    public class ConcreteArrow : Arrow
    {
        private SubjectState _subjectState;

        public SubjectState SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
    }

    #endregion The Subject

    #region The Observer

    // the observer abstract class
    public abstract class Maze
    {
        public abstract void Update();
    }

    public class ConcreteMaze : Maze
    {
        private string _name;
        private SubjectState _observerState;
        private ConcreteArrow _subject;

        public ConcreteMaze(ConcreteArrow subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }

        public override void Update()
        {
            _observerState = _subject.SubjectState;
            
            // TODO: 

            //Update the correct position of the arrow.
            //Get the state (X, Y coordinates) and Direction of the Arrow(Subject). 
            //search each Cell in the maze for the matching (coordinate)
            //Update the correct image.

            // This should interact with the UI Grid
            // Pass the 'model' to the UI Controller
        }
    }

    #endregion The Observer
}
