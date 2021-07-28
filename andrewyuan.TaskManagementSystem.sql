use TaskManagementSystem


select * from Users
select * from Tasks
select * from TasksHistory

insert into [Users] ([Email], [Password], [Fullname], [Mobileno]) values ('jones123@gmail.com', 'Password1', 'Jones White', '9097775418')
insert into [Users] ([Email], [Password], [Fullname], [Mobileno]) values ('akim1986@gmail.com', 'April1986', 'Andrew Kim', '9095576515')
insert into [Users] ([Email], [Password], [Fullname], [Mobileno]) values ('emma64@gmail.com', 'Wonder1984', 'Emma Stone', '9098745476')
insert into [Users] ([Email], [Password], [Fullname], [Mobileno]) values ('dwightkschrute@gmail.com', 'Beetz4', 'Dwight Schrute', '9093745155')

insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority]) values (1, 'Setup Computers', 'Set up four computers', '2021-07-20', '1')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority]) values (2, 'Order Supplies', 'order office supplies', '2021-07-20', '2')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority]) values (3, 'Schedule Meeting', 'schedule meeting with vp', '2021-07-21', '3')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority]) values (1, 'Clean Desk', 'Wipe down desk', '2021-07-27','3')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority], [Remarks]) values (1, 'Fix plumbing', 'fix the toilet on the 2nd floor', '2021-07-30', '1', 'tape off area')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority]) values (2, 'Clean Desk', 'Wipe down desk', '2021-07-27', '3')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority], [Remarks]) values (2, 'Organize Files', 'Organize tax documents', '2021-07-31', '2', 'must be done before august')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority]) values (3, 'Clean Desk', 'Wipe down desk', '2021-07-27', '3')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority], [Remarks]) values (3, 'Plan company picnic', 'figure out where to eat and what to bring', '2021-08-06', '2', 'get food allergies')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority]) values (4, 'Clean Desk', 'Wipe down desk', '2021-07-27', '3')
insert into [Tasks] ([UsersId], [Title], [Description], [DueDate], [Priority], [Remarks]) values (4, 'Find new clients', 'look for potential customers', '2021-07-30', '2', 'check yellow pages')

insert into [TasksHistory] ([TaskId], [Title], [Description], [DueDate], [Completed], [Remarks], [UsersId]) 
values (1, 'Setup Computers', 'Set up four computers', '2021-07-20', '2021-07-20', 'Ask about OS preference', 1)
insert into [TasksHistory] ([TaskId], [Title], [Description], [DueDate], [Completed], [UsersId]) 
values (2, 'Order Supplies', 'order office supplies', '2021-07-20', '2021-07-20', 2)
insert into [TasksHistory] ([TaskId], [Title], [Description], [DueDate], [Completed], [UsersId]) 
values (3, 'Schedule Meeting', 'schedule meeting with vp', '2021-07-21', '2021-07-21', 3)

delete from Tasks where Id < 4