using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwOOPFirst
{
    class Door
    {
        public enum DoorStatus
        {
            Open,Closed
        }

        public DoorStatus Status { get; private set; } = DoorStatus.Closed;

        public Door(DoorStatus status) => Status = status;

        public void Open()
        {
            if (Status == DoorStatus.Closed)
                Status = DoorStatus.Open;
        }

        public void Close()
        {
            if (Status == DoorStatus.Open)
                Status = DoorStatus.Closed;
        }
    }

    
}
