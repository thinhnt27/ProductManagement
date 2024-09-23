import React, { useEffect, useState } from "react";
import { Form, Input, Select } from "antd";
import DashboardTemplate from "../../components/dashboard-template";
import api from "../../config/axios";

function ManageProduct() {
  const [categories, setCategories] = useState([]);

  const fetchCategories = async () => {
    const response = await api.get('categories');
    console.log(response.data);
    setCategories(response.data);
  };

  useEffect(() => {
    fetchCategories();
  }, []);

  const columns = [
    {
      title: "Id",
      dataIndex: "productId",
      key: "productId",
    },
    {
      title: "Name",
      dataIndex: "productName",
      key: "productName",
    },
  ];

  const formItems = (
    <>
      <Form.Item name="productName" label="Name">
        <Input />
      </Form.Item>
      <Form.Item name="categoryId" label="Category">
        <Select
          options={categories.map(item => ({
            value: item.categoryId,
            label: item.categoryName,
          }))}
        />
      </Form.Item>
    </>
  );

  return (
    <DashboardTemplate
      columns={columns}
      apiURI="products"
      formItems={formItems}
      idName="productId"
    />
  );
}

export default ManageProduct;
