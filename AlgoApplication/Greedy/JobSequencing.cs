using AlgoIApplication;
using System;
using System.Collections.Generic;

namespace AlgoApplication.Greedy
{
    public class JobSequencing : IAlgorithm
    {
        public void Run()
        {
            Console.WriteLine("Greedy Algorithm for Jobs with deadlines and profits using defaults inputs.");

            Job job = new();
            job.PopulateDefaultJobList();

            // Calling function
            job.PrintJobScheduling(4);
            Console.Write(Environment.NewLine);
        }
    }

    internal class Job
    {
        protected List<Job> _jobList { get; set; }

        // Each job has a unique-id,
        // profit and deadline
        char id;
        public int profit;
        public int deadline;

        // Constructors
        public Job() { }

        public Job(char id, int deadline, int profit)
        {
            this.id = id;
            this.deadline = deadline;
            this.profit = profit;
        }

        // Arguments arraylist and no. of jobs to schedule
        public void PrintJobScheduling(int t)
        {
            // Length of array
            int n = _jobList.Count;

            JobComparer jc = new();
            // Sort all jobs according to
            // decreasing order of profit
            _jobList.Sort(jc);

            // To keep track of free time slots
            bool[] result = new bool[t];

            // To store result (Sequence of jobs)
            char[] job = new char[t];

            // Iterate through all given jobs
            for (int i = 0; i < n; i++)
            {
                // Find a free slot for this job
                // (Note that we start from the
                // last possible slot)
                for (int j
                     = Math.Min(t - 1, _jobList[i].deadline - 1);
                     j >= 0; j--)
                {

                    // Free slot found
                    if (result[j] == false)
                    {
                        result[j] = true;
                        job[j] = _jobList[i].id;
                        break;
                    }
                }
            }

            // Print the sequence
            Console.WriteLine();
            foreach (var _job in _jobList)
            {
                Console.Write($"JobID: {_job.id} Deadline: {_job.deadline} Profit: {_job.profit} ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Following is maximum profit sequence of jobs:");
            foreach (char jb in job)
            {
                Console.Write(jb + " ");
            }
            Console.WriteLine();
        }

        public void PopulateDefaultJobList()
        {
            _jobList = new();
            _jobList.Add(new Job('a', 2, 100));
            _jobList.Add(new Job('b', 1, 19));
            _jobList.Add(new Job('c', 2, 27));
            _jobList.Add(new Job('d', 1, 25));
            _jobList.Add(new Job('e', 3, 15));
            _jobList.Add(new Job('f', 3, 35));
            _jobList.Add(new Job('g', 4, 10));
            _jobList.Add(new Job('h', 4, 50));
        }
    }

    internal class JobComparer : IComparer<Job>
    {
        public int Compare(Job x, Job y)
        {
            if (x.profit == 0 || y.profit == 0)
            {
                return 0;
            }

            return (y.profit).CompareTo(x.profit);

        }
    }
}
