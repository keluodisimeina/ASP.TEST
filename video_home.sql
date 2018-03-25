create database movies;
go
use movies;
go
create table types
(id int identity(1,1) primary key,
tname varchar(50) not null
);
go
create table movielist
(
id int identity(1,1) primary key,
mname varchar(100) not null,
maker varchar(50),
url varchar(100),
img varchar(100),
playtimes int default(0),
isrecommend bit default(0),
onlinetime datetime,
brief text,
tid int,
constraint movielist_type_fk foreign key(tid) references types(id)
);
go
create table admins
(
id int	identity(1,1) primary key,
name varchar(12) not null,
pwd varchar(128) not null,
limit int default(2)
);
go


insert into admins(name,pwd,limit) values('admin',' 81dc9bdb52d04dc20036dbd8313ed055',1);
insert into admins(name,pwd,limit) values('jack',' d93591bdf7860e1e4ee2fca799911215 ',2);
insert into admins(name,pwd,limit) values('rose',' 81dc9bdb52d04dc20036dbd8313ed055',2);
go

insert into types values('ϲ��')
insert into types values('����')
insert into types values('�ƻ�')
insert into types values('����')
insert into types values('���')
insert into types values('����')
go


insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('�����ط���','jan','movies/hu.mp4','images/movies/xltfn.png',187,0,'2015-1-13 12:12:00','����У�����ŵĻ�������¡�ؾ��У�ѧ��ʱ���������ŵ����忴����Χ��ҵ�ɹ�����ͬѧ�����з�����ζ�������߷�����',1);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('����֤��','Tom','movies/hu.mp4','images/movies/wszr.png',99,0,'2015-2-12 12:12:00','��ϰŮ�����Լ���ʧ������Ŀ���˵ܵܵ��������Լ�Ҳ˫Ŀʧ����Ҳ����ʧ���̼��������йٵĻ�Ծ',2);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('�����ְ���','jan','movies/hu.mp4','images/movies/dszaq.png',97,0,'2015-3-14 12:12:00','ʧ��Ů��ʦ�����ڻس̵ķɻ���ʧ��ʹ�ޣ�����������������ע�⡣�ؼҺ������������������ּ��Ŷ�����',2);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('С���˴�����','Marry','movies/hu.mp4','images/movies/xhrdym.png',236,0,'2015-4-13 12:12:00','�ӵ�����֮����һ����ֵ����������������ɫ�������ϡ����ǲ��Ͻ������ɱ䣬���ڳ�Ϊ��������Ϥ',1);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('�����㰮��','jan','movies/hu.mp4','images/movies/yznaw.png',87,1,'2015-5-13 12:12:00','����ʦ��С������ӵ��һ��ֻ�к���û�����˵ġ��Ҹ��������Ե�ɺϽ�ʶ�����������˖��塣�������С�����кøУ�ȴδ�ϵ�����С����ֻ��Ҫ�����ӣ��������·ǻ��������ɡ�Ϊ��ѧ�������ں�������ʱ����С��֪ͨ�˖��壬�˿����������Լ����ˡ�����',2);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('Сʱ��3���ݽ�ʱ��','jan','movies/hu.mp4','images/movies/xsd3.png',87,1,'2015-6-13 12:12:00','��Сʱ��3.0�̽�ʱ������������������������桢��������λ���ǣ��Լ���׼����Ϫ����Դ���������ܳ�⡢Neil������������һȺ�ˣ����ǻ����������У԰��������������Ĺ�������֮�е���ʧ����㯡�����ȴ�ֲ��ܲ�����ֱǰ�Ĺ��¡�',1);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('���������','jan','movies/hu.mp4','images/movies/fkwxr.png',87,1,'2015-7-13 12:12:00','�ɰ���������Сŷ������ͬ�鲨������һֱ��Ѱ��һ���������Ǿ�ס�ĵط�����һ�δεĳ��Բ���ʧ��֮�����ǵ�½�˵����ҽ������ϵ����������ת�ơ���Ϊһ�����⣬Сŷ��Ϊ�˲������˵�ȫ��ͨ��Ŀ�ꡣ�����������������Ȱ�ð�յĵ���Ů����',1);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('���ŷ���2','jan','movies/hu.mp4','images/movies/amfy2.png',87,1,'2015-8-13 12:12:00','������̳�ġ�ħ���֡�ʯһ���ڲμӺ�������ĺ��������ɶ�ʱ��ͻ����·������Ůɱ�ַ��������֪�����ܾɵ�D.O.A��֯������ڣ������ǵ�Ŀ�겻����ɱ��ʯһ�ᣬ��Ҫ׽��Я��֯һ����ʮ����Ԫ�ʽ�Ǳ�ӵĻ��С���� Ϊ����С��������D.O.A����ı��',1);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('����û�뵽','jan','movies/hu.mp4','images/movies/wwnxd.png',375,0,'2015-9-15 12:18:00','��˿С�����󴸣����������볣�˲�ͬ��������⣬����ЩС������������ڼ��������������������û�뵽���ǣ���������ɮʦͽ��������������˷�������ת����������ɮʦͽ��������˵����������Ҳ���ޱ����Ƶĵڰ�ʮ���ѡ�˫�����������һ���మ��ɱ���������������ð�ա�',5);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('��ʧ�İ���','jan','movies/hu.mp4','images/movies/xsdar.png',87,0,'2015-10-16 12:12:00','�ı��Լ��򰲡����յ�ͬ��С˵���ɴ���������ִ���������������� ����ɯ���¡��ɿˡ������������ˡ�����˹�����ݵ����ɾ�㤵�Ӱ����Ƭ������ƽ���ֶ�����һ�Է��ޣ�ͻȻ��һ������ȴ��ʧ�������ɷ�ͨ�����ַ�ʽ���Ѱ�ң�Ȼ�����������µ�һ���ռ���ȴ���֣������������������ɷ�����ɱ����',5);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('̽�鵵��','jan','movies/hu.mp4','images/movies/tlda.png',87,0,'2015-11-15 12:12:00','�����ǡ�ä����̽���ķ����н�²�������ͻȻ���ֵ������´�����ԭ��ƽ�������ԭ������ط�������һ����˵����ҹ��������㳡���˿��Կ�����һ�����硣����Ϊ��������������ºͼ�������ҹ̽����㳡�󣬾�Ȼ�ڼ��￴���Լ���ȥ����ĸ��׵���Ӱ�������ҵ��²���Ѱ�����',5);
insert into movielist(mname,maker,url,img,playtimes,isrecommend,onlinetime,brief,tid)
values('Ħ���ж�','jan','movies/hu.mp4','images/movies/mkxd.png',87,0,'2015-12-17 12:12:00','������������������츳��������Ϊƽ���ع����¶�Ժ��÷������С����ƶ���������渻�����ź���ǰ������������ź���һ��ǧ����Ҫ�չ������Ͻ֣�ȴ�⵱�������ҷ��ԡ��ڰ���ı����С���׳����ϲƲ������Ӷ�ڿ�������ƣ�����Ϊ׷��С�ᡢ���ƴ�ͬ������� �����������ܹ����̾�֮�У�ͨ�����ȵ�����ӳ�',6);
