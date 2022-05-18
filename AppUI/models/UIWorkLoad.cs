using System;
using DBMS;
using DBMS.models;

namespace AppUI.models
{
    public class UIWorkLoad : UIModel
    {
        private WorkLoad _WorkLoad { get; set; }

        public string Name
        {
            get => _WorkLoad.Name;
            set
            {
                _WorkLoad.Name = value;
                PropagateChange();
            }
        }
        
        public int ChunkSize
        {
            get => _WorkLoad.ChunkSize;
            set
            {
                _WorkLoad.ChunkSize = value;
                PropagateChange();
            }
        }
        
        public int MaxParallels
        {
            get => _WorkLoad.MaxParallels;
            set
            {
                _WorkLoad.MaxParallels = value;
                PropagateChange();
            }
        }

        public DateTime ReleaseDate
        {
            get => _WorkLoad.ReleaseDate;
            set
            {
                _WorkLoad.ReleaseDate = value;
                PropagateChange();
            }
        }

        public UIWorkLoad(long id) : this(DB.Internal.Load<WorkLoad>(new {id}))
        {
        }

        public UIWorkLoad(WorkLoad wl)
        {
            _WorkLoad = wl;
            SetBouncer(() => _WorkLoad.Save());
        }

        public WorkLoad GetWorkload() => _WorkLoad;
    }
}