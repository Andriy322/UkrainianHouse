/*запит який виведе перелік матеріалів,які не постачались у поточному місяці*/
SELECT DISTINCT mat.material_name
FROM Material as mat
LEFT JOIN (SELECT DISTINCT oper.material_id FROM Operation as oper
JOIN Date as dat 
ON oper.date_id = dat.date_id          
WHERE dat.month = month(GETDATE())) as sub
ON sub.material_id = mat.material_id
where sub.material_id is null



/*запит,який виведе перелік тих працівників,які є проджект менеджерами одночасно на декількох проектах*/
SELECT e.employee_id, e.first_name, e.last_name
FROM Employee as e  
JOIN Project as p
ON p.employee_id = e.employee_id
WHERE specialization= 'manager'
GROUP BY e.employee_id, e.first_name, e.last_name
having count(distinct project_id)>1;

SELECT e.employee_id, e.first_name, e.last_name,count(*) as project_count--count(project_id) as project_c,count(distinct project_id) as project_distc
FROM Employee as e  
JOIN Project as p
ON p.employee_id = e.employee_id
WHERE specialization= 'manager'
GROUP BY e.employee_id, e.first_name, e.last_name
having count(*)>1;

SELECT e.employee_id, e.first_name, e.last_name,count(*),count(first_name) as count_first --count(*) as project_count,count(project_id) as project_c,count(distinct project_id) as project_distc
FROM Employee as e  
LEFT JOIN Project as p
ON p.employee_id = e.employee_id
GROUP BY e.employee_id, e.first_name, e.last_name

SELECT count(*)
FROM Employee as e  
JOIN Project as p
ON p.employee_id = e.employee_id
WHERE specialization= 'manager'

--having count(project_id)>1;

SELECT e.employee_id, e.first_name, e.last_name
FROM Employee as e,Project as p 
WHERE p.employee_id = e.employee_id AND specialization= 'manager'
GROUP BY e.employee_id, e.first_name, e.last_name
having count(distinct project_id)>1;

/**/

SELECT e.first_name,e.last_name
FROM Employee as e
WHERE specialization = 'manager';



SELECT e.first_name,e.last_name,e.specialization
FROM Employee as e;


SELECT e.specialization,count(*) as count_people
FROM Employee as e
--WHERE specialization = 'manager'
GROUP BY e.specialization
having count(*)>1;


SELECT p.project_id,p.employee_id,p.project_name,e.first_name,e.last_name,e.specialization
FROM Employee as e
JOIN Project as p
ON p.employee_id = e.employee_id;

SELECT e.first_name,e.last_name,e.specialization
FROM Employee as e
WHERE e.employee_id IN(SELECT employee_id FROM Project as p)

SELECT p.project_id,p.employee_id,p.project_name,e.first_name,e.last_name,e.specialization
FROM Employee as e,Project as p
WHERE e.employee_id = p.employee_id;