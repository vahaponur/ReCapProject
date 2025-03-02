﻿using Core.Utilities.Result.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBankService
    {
        IResult Payment(CreditCard creditCard);
    }
}
