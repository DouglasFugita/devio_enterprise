﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NStore.Core.Messages
{
    public class Event:Message, INotification
    {

    }
}