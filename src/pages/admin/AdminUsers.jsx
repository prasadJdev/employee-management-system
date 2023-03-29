import React from 'react'
import Content from '../../components/dashboard/Content'
import UsersTable from './components-admin/UsersTable'

export default function AdminUsers() {
  return (
    <Content ContentElement={UsersTable}/>
  )
}
