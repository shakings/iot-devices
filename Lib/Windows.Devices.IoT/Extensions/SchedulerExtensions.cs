﻿// Copyright (c) Microsoft. All rights reserved.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.Devices.IoT
{
    static internal class SchedulerExtensions
    {
        static private void GetSubscriber(Delegate subscriber, out AsyncAction a, out Action s)
        {
            a = subscriber as AsyncAction;
            s = subscriber as Action;

            if ((a == null) && (s == null))
            {
                throw new InvalidOperationException(Strings.InvalidSubscriberType);
            }
        }

        static public void Resume(this IScheduler scheduler, Delegate subscriber)
        {
            AsyncAction a;
            Action s;
            GetSubscriber(subscriber, out a, out s);
            if (a != null)
            {
                scheduler.Resume(a);
            }
            else
            {
                scheduler.Resume(s);
            }
        }

        static public void Schedule(this IScheduler scheduler, Delegate subscriber, ScheduleOptions options)
        {
            AsyncAction a;
            Action s;
            GetSubscriber(subscriber, out a, out s);
            if (a != null)
            {
                scheduler.Schedule(a, options);
            }
            else
            {
                scheduler.Schedule(s, options);
            }
        }

        static public void Suspend(this IScheduler scheduler, Delegate subscriber)
        {
            AsyncAction a;
            Action s;
            GetSubscriber(subscriber, out a, out s);
            if (a != null)
            {
                scheduler.Suspend(a);
            }
            else
            {
                scheduler.Suspend(s);
            }
        }

        static public void Unschedule(this IScheduler scheduler, Delegate subscriber)
        {
            AsyncAction a;
            Action s;
            GetSubscriber(subscriber, out a, out s);
            if (a != null)
            {
                scheduler.Unschedule(a);
            }
            else
            {
                scheduler.Unschedule(s);
            }
        }

        static public void UpdateSchedule(this IScheduler scheduler, Delegate subscriber, ScheduleOptions options)
        {
            AsyncAction a;
            Action s;
            GetSubscriber(subscriber, out a, out s);
            if (a != null)
            {
                scheduler.UpdateSchedule(a, options);
            }
            else
            {
                scheduler.UpdateSchedule(s, options);
            }
        }
    }
}
