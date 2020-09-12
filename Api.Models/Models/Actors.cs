﻿using System;
using System.Collections.Generic;

namespace Api.Models.Models
{
    public class Actors
    {
        public int ActorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthday { get; set; }

        //Эти конструкторы нужны только для генерирования фальшивых данных, избавься от них и от самих данных
        public Actors()
        {
        }

        public Actors(int actorId, string firstname, string lastname, DateTime? birthday)
        {
            ActorId = actorId;
            Firstname = firstname;
            Lastname = lastname;
            Birthday = birthday;
        }

        // navigational properties
        // this is composite key to get many to many movies - actors
        public virtual ICollection<Starring> Starring { get; set; }
    }
}