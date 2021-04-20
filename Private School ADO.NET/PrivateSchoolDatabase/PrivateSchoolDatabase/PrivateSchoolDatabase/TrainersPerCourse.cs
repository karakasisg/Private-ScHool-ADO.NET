using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolDatabase
{
    class TrainersPerCourse
    {
        private List<Trainer> _trainers;
        public Course Course { get; set; }

        public TrainersPerCourse()
        {
            _trainers = new List<Trainer>();
        }

        public TrainersPerCourse(Course course)
        {
            Course = course;
            _trainers = new List<Trainer>();
        }

        public void AddTrainer(Trainer trainer)
        {
            _trainers.Add(trainer);
        }

        public void ListTrainers()
        {
            for (int i = 0; i < _trainers.Count; i++)
            {
                Console.WriteLine("\t" + _trainers[i]);
            }
        }

        public bool TrainersListExistsTrainerWithId(int trainerId)
        {
            return _trainers.Exists(x => x.TrainerId == trainerId);
        }
    }
}
