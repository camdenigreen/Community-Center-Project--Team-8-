[33mcommit 940523e1d0bb3f1e595bc40f9210c23cd398c7e4[m[33m ([m[1;36mHEAD -> [m[1;32mtatenda[m[33m, [m[1;31morigin/tatenda[m[33m, [m[1;32msee[m[33m)[m
Author: Tatenda-k <sekabanj@ksu.edu>
Date:   Mon Apr 15 18:41:06 2024 -0500

    started on person

[33mcommit 2e150d58e63771b70ce367e1e282595f62a065cf[m
Merge: b8d28a4 4875917
Author: Tatenda-k <sekabanj@ksu.edu>
Date:   Fri Apr 12 09:48:23 2024 -0500

    Merge remote-tracking branch 'origin/Camden_Xaml' into tatenda

[33mcommit b8d28a4673ae9478b8c7195cbc9c907d9531dadb[m
Author: Tatenda-k <sekabanj@ksu.edu>
Date:   Fri Apr 12 07:52:17 2024 -0500

    procedures

[33mcommit 487591748164298fd8e61004756a952720df85a0[m
Author: camdenigreen <cigreen@ksu.edu>
Date:   Fri Apr 12 01:23:02 2024 -0500

    New package and add event basics

[33mcommit 87a76efab77a4cd767b21ee533ef6549171543e7[m
Author: camdenigreen <cigreen@ksu.edu>
Date:   Thu Apr 11 23:23:49 2024 -0500

    Aggregated query xaml blueprint

[33mcommit 18e848302117986c4c0d2dbfcae6a0eaf4d36e4e[m
Merge: 635687f 5e0b4a6
Author: camdenigreen <cigreen@ksu.edu>
Date:   Thu Apr 11 18:48:06 2024 -0500

    Merge remote-tracking branch 'origin/joshzru' into Camden_Xaml

[33mcommit 5e0b4a6d05769730543376da8828499e5bbcccd5[m[33m ([m[1;31morigin/joshzru[m[33m)[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Mon Apr 8 10:22:17 2024 -0500

    Setup repositories.

[33mcommit eca7b2cc78a6239934c83b8cc85aa6ae0e1cf218[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Mon Apr 8 08:12:00 2024 -0500

    Added abstract datadelegates and exceptions. Updated CommandExecutor.

[33mcommit 635687fa11c765b489cffb3f442511e8e6f17717[m
Author: camdenigreen <cigreen@ksu.edu>
Date:   Sun Apr 7 23:55:34 2024 -0500

    Menu Select Control (its 4 buttons smile)

[33mcommit 588a325a99d7496e1ce65a83062f9cdde5378ba3[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Fri Apr 5 09:54:59 2024 -0500

    Finished model objects (Charge, Event, Group, Payment, Person).

[33mcommit a7821dad5c8c1370832bfc779cbd9472ef3061dc[m
Author: Joshua Zrubek <joshzru@gmail.com>
Date:   Fri Apr 5 09:20:25 2024 -0500

    Repositories implement from interfaces.

[33mcommit 925353a83f9f66a4da98bffd5136819ec3b2ded7[m
Author: Joshua Zrubek <joshzru@gmail.com>
Date:   Fri Apr 5 09:16:05 2024 -0500

    Added methods to interfaces.

[33mcommit 3f91d965baa29a3435306af4c5ba6821806b63f0[m
Author: Joshua Zrubek <joshzru@gmail.com>
Date:   Fri Apr 5 09:02:18 2024 -0500

    Changed FirstName, LastName, and PhoneNumber to be unique in Tables.sql.

[33mcommit 24e81ac6416b5f13d159097d5191cc0a47811d39[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Fri Apr 5 08:39:33 2024 -0500

    Projecct metadata.

[33mcommit ed83b11431c2df457ed7ae0c879c09f77d9d9f59[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Thu Apr 4 21:04:59 2024 -0500

    Added base DataDelegate and repositories.

[33mcommit 9b580d2885043f1154518e10d10dbd0ff6734b24[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Tue Apr 2 19:02:52 2024 -0500

    Changed some comments, removed Trusted_Connection=yes in connectionString.

[33mcommit 11e28f9c0b04c47b347e9079c882bf4174962e9a[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Tue Apr 2 13:20:39 2024 -0500

    Program now properly rebuilds tables and populates People.People, People.Groups, and Events.Events.

[33mcommit 92df7bee9f12b7da0aa5609334ebe48d7c433ac9[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Tue Apr 2 13:19:54 2024 -0500

    Made GroupID in Events.Events Nullable.

[33mcommit 5bf21eb4b4b2fdca52a6d97ca9fea6b04086227d[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Tue Apr 2 13:19:24 2024 -0500

    Renamed People.Groups and Events.Events Name column to be unique in their populate scripts.

[33mcommit 790e05c89ce506ed042918fa0d799fcd32cd7690[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Tue Apr 2 12:49:42 2024 -0500

    Test script files for People.People, People.Groups, and Events.Events added.

[33mcommit c11204c1cec6d4f0da43f26efe2852b8f1c19f6a[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Tue Apr 2 12:25:48 2024 -0500

    Added .sql to populate scripts in PopulateTables.

[33mcommit a347c5ddf4075f93c1f52b95398d3072279785be[m
Author: Joshua Zrubek <joshzru@gmail.com>
Date:   Tue Apr 2 08:37:21 2024 -0500

    Base code for populating tables complete.

[33mcommit 0796f13c3399b9ad1b8ce4eff92f221bf1cff121[m
Author: Joshua Zrubek <joshzru@gmail.com>
Date:   Tue Apr 2 08:36:43 2024 -0500

    Change function call from Setup object.

[33mcommit 549f87848593d2bb48a96259f792c446f7b72bba[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Mon Apr 1 21:06:43 2024 -0500

    Program properly drops and creates all tables.

[33mcommit be35e721cb9b8e9d2a11f4ba98fe3c15594bbda4[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Mon Apr 1 21:03:26 2024 -0500

    Rerearranged dropped table execution and creation.

[33mcommit 692b9c416a330677aaa13384865152c5d9e63507[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Mon Apr 1 20:58:25 2024 -0500

    Rearranged dropped table execution.

[33mcommit d5ec41d2074d9a8e4330ab3d746a3915e7d0adf1[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Mon Apr 1 19:40:50 2024 -0500

    Created projects for data handling.

[33mcommit 175648a217a34a27d8647ecbc08dd829e8d0986f[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Mon Apr 1 11:45:38 2024 -0500

    Create program file that will be used to setup database.

[33mcommit 01af357650cc53033d9bc664fa121be513e534f0[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Mon Apr 1 11:36:06 2024 -0500

    Add/rearange script to create tables.

[33mcommit c2e572d5858f602f92b02735cf57fcbc350e8b2c[m
Author: Josh Zrubek <joshzru@gmail.com>
Date:   Mon Apr 1 11:35:23 2024 -0500

    Create DatabaseSetup Project.

[33mcommit 8dea45381a25cd1cd53d7fa55d093df30bc4d28a[m[33m ([m[1;31morigin/master[m[33m, [m[1;31morigin/HEAD[m[33m, [m[1;32mmaster[m[33m)[m
Author: camdenigreen <142830084+camdenigreen@users.noreply.github.com>
Date:   Fri Mar 22 09:53:00 2024 -0500

    Create README.md

[33mcommit 13d9d03fc3afaa77c62b3f371e568d7c6a5e2437[m
Author: camdenigreen <cigreen@ksu.edu>
Date:   Fri Mar 22 09:44:01 2024 -0500

    Add project files.

[33mcommit 7f1701edf9df86ed90c1871976722ad41431589a[m
Author: camdenigreen <cigreen@ksu.edu>
Date:   Fri Mar 22 09:43:59 2024 -0500

    Add .gitattributes and .gitignore.
