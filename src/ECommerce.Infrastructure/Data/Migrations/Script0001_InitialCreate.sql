create table if not exists categories (
    id integer primary key,
    name varchar(200) not null,
    description text
);

create table if not exists chemical_elements(
    id integer primary key,
    symbol varchar(3) not null,
    name varchar(200) not null,
    atomic_mass decimal not null,
    price_amount decimal not null,
    price_currency varchar(3) not null,
    is_radioactive boolean,
    is_synthetic boolean
);

create table if not exists element_categories(
    element_id integer not null,
    category_id integer not null,
    primary key (element_id, category_id),
    foreign key (element_id) references chemical_elements(id),
    foreign key (category_id) references categories(id)
);