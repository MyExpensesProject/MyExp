'use client';

import React from 'react';
import Link from 'next/link';

const Page = () => {
  return (
      <div className='flex flex-row space-x-4'>
        <div className='flex flex-col bg-white p-4 shadow-lg w-4/12 rounded-lg space-y-4'>
          <p className='font-bold'>Разделы деклараций</p>
          <Link href="/modules/declaration/STI100_4" className='flex'>
            <span>🔥</span>
            Единая налоговая декларация
          </Link>
          <Link href="/modules/declaration/STI100_4" className='flex'>
            <span>🔥</span>
            Единая налоговая декларация
          </Link>
          <Link href="/modules/declaration/STI100_4" className='flex'>
            <span>🔥</span>
            Единая налоговая декларация
          </Link>
          <Link href="/modules/declaration/STI100_4" className='flex'>
            <span>🔥</span>
            Единая налоговая декларация
          </Link>
        </div>
        <div className='flex flex-col bg-white p-4 shadow-lg w-8/12 rounded-lg'>
          <Link href="/modules/declaration/STI100_3" className='flex'>
            <span>🔥</span>
            Единая налоговая декларация физического лица, не осуществляющего предпринимательскую деятельность (01.01.2021 - 31.12.2021) (FORM STI-100_3)
          </Link>
          <Link href="/modules/declaration/STI100_4" className='flex'>
            <span>🔥</span>
            Единая налоговая декларация физического лица, не осуществляющего предпринимательскую деятельность (01.01.2022 - ) (FORM STI-100_4)
          </Link>
        </div>
      </div>
  );
};

export default Page;