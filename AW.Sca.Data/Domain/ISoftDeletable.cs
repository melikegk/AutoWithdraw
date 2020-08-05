﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AW.Sca.Data.Domain
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
